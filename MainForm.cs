using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoLogGenerator
{
    /// <summary>
    /// Main form for the TODO Log Generator application.
    /// This form handles user interactions such as selecting a directory, generating logs, and saving logs.
    /// </summary>
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        private bool isProcessing = false; // Indicates if a task is currently in progress
        private bool hasTodos = false;     // Indicates if TODOs were found during the scan

        public MainForm()
        {
            InitializeComponent();
            btnStop.Enabled = false;  // Initially, Stop button is disabled until scanning starts
        }

        /// <summary>
        /// Event handler for the "Select Directory" button click.
        /// Allows the user to select a directory to scan for TODO comments.
        /// </summary>
        private void btnSelectDirectory_Click(object sender, EventArgs e)
        {
            using (var dialog = new Ookii.Dialogs.WinForms.VistaFolderBrowserDialog())
            {
                dialog.Description = "Select a folder to scan for TODOs.";
                dialog.UseDescriptionForTitle = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    lblSelectedDirectory.Text = $"Selected Directory: {dialog.SelectedPath}";
                }
            }
        }

        /// <summary>
        /// Event handler for the "Generate Log" button click.
        /// Initiates the scanning of the selected directory for TODO comments.
        /// </summary>
        private async void btnGenerateLog_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedDirectory = lblSelectedDirectory.Text.Replace("Selected Directory: ", "").Trim();

                if (string.IsNullOrEmpty(selectedDirectory) || selectedDirectory == "None")
                {
                    MessageBox.Show("Please select a directory first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cancellationTokenSource = new CancellationTokenSource();
                var token = cancellationTokenSource.Token;

                isProcessing = true;
                hasTodos = false; // Reset TODO state
                btnSaveLog.Enabled = false; // Disable Save Log while processing
                btnStop.Enabled = true;  // Enable Stop button when processing starts
                btnSelectDirectory.Enabled = false; // Disable Select Directory while processing

                txtStatus.Clear();

                // Fetch files asynchronously
                var files = await Task.Run(() => FileProcessor.GetFilesFromDirectory(selectedDirectory), token);

                if (files == null || files.Count == 0)
                {
                    txtStatus.AppendText("No files found in the selected directory." + Environment.NewLine);
                    return;
                }

                var allTodos = new List<string>();

                // Process files to extract TODOs (this happens in parallel)
                await Task.Run(() =>
                {
                    foreach (var file in files)
                    {
                        if (token.IsCancellationRequested)
                        {
                            txtStatus.Invoke((Action)(() => txtStatus.AppendText("Operation cancelled by user." + Environment.NewLine)));
                            return;
                        }

                        var todos = FileProcessor.ExtractTodosFromFile(file, selectedDirectory);
                        lock (allTodos)
                        {
                            allTodos.AddRange(todos); // Thread-safe collection update
                        }
                    }
                }, token);

                // Display extracted TODOs
                if (allTodos.Count > 0)
                {
                    hasTodos = true;
                    foreach (var todo in allTodos)
                    {
                        var parts = todo.Split('|');
                        var pathAndLine = parts[0];
                        var todoText = parts[1];
                        txtStatus.AppendText($"[{pathAndLine}] {todoText}{Environment.NewLine}");
                    }
                }
                else
                {
                    txtStatus.AppendText("No TODOs found in the selected directory." + Environment.NewLine);
                }
            }
            catch (OperationCanceledException)
            {
                txtStatus.AppendText("Operation cancelled by user." + Environment.NewLine);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Access denied to some files or directories.\nDetails: {ex.Message}", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isProcessing = false;
                btnSaveLog.Enabled = hasTodos; // Enable Save Log if TODOs exist
                btnStop.Enabled = false;  // Disable Stop button once processing is complete
                btnSelectDirectory.Enabled = true; // Re-enable Select Directory once processing is complete
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
            }
        }

        /// <summary>
        /// Event handler for the "Stop" button click.
        /// Cancels the current operation if in progress.
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                isProcessing = false;
                btnSaveLog.Enabled = hasTodos; // Allow Save Log if TODOs exist
                MessageBox.Show("Operation cancellation requested.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnStop.Enabled = false;  // Disable Stop button after cancellation
            }
        }

        /// <summary>
        /// Event handler for the "Save Log" button click.
        /// Saves the extracted TODO comments to a log file.
        /// </summary>
        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (isProcessing)
                {
                    MessageBox.Show("Please wait until the current operation is completed or stopped.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!hasTodos)
                {
                    MessageBox.Show("No TODOs found to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string selectedDirectory = lblSelectedDirectory.Text.Replace("Selected Directory: ", "").Trim();
                if (string.IsNullOrEmpty(selectedDirectory) || selectedDirectory == "None")
                {
                    MessageBox.Show("Please select a directory first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string logsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
                if (!Directory.Exists(logsDirectory))
                {
                    Directory.CreateDirectory(logsDirectory);
                }

                string logFileName = $"{Path.GetFileName(selectedDirectory)}_TODOLog.txt";
                string logFilePath = Path.Combine(logsDirectory, logFileName);

                // Prepare log content
                var logContent = txtStatus.Lines
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Where(line => !line.Contains("Operation cancelled by user."))
                    .Where(line => !line.Contains("No TODOs found in the selected directory."))
                    .Aggregate("", (current, line) => current + line + Environment.NewLine);

                File.WriteAllText(logFilePath, logContent.Trim());
                MessageBox.Show($"Log saved successfully to: {logFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Access denied while saving the log file.\nDetails: {ex.Message}", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while saving the log:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}