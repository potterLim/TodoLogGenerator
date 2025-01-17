using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TodoLogGenerator
{
    /// <summary>
    /// FileProcessor class responsible for file handling tasks like retrieving files and extracting TODO comments.
    /// </summary>
    public static class FileProcessor
    {
        private static readonly HashSet<string> excludedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".exe", ".dll", ".sys", ".tmp", ".bin", ".log", ".bak", ".dat" // File extensions to exclude from scanning
        };

        /// <summary>
        /// Retrieves all files from the specified directory and its subdirectories, excluding specific file extensions.
        /// </summary>
        /// <param name="directoryPath">The path of the directory to scan for files.</param>
        /// <returns>A list of file paths that match the criteria.</returns>
        public static List<string> GetFilesFromDirectory(string directoryPath)
        {
            var allFiles = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);

            // Exclude files with specific extensions (e.g., .exe, .dll, etc.)
            return allFiles.Where(file => !excludedExtensions.Contains(Path.GetExtension(file))).ToList();
        }

        /// <summary>
        /// Extracts TODO comments from a specific file.
        /// </summary>
        /// <param name="filePath">The path of the file to process.</param>
        /// <param name="baseDirectory">The base directory used to calculate the relative path.</param>
        /// <returns>A list of TODO comments with their relative file paths and line numbers.</returns>
        public static List<string> ExtractTodosFromFile(string filePath, string baseDirectory)
        {
            var todos = new List<string>();

            try
            {
                var lines = File.ReadAllLines(filePath);
                string relativePath = GetRelativePath(baseDirectory, filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("// TODO:") || lines[i].Contains("/* TODO:"))
                    {
                        string todoContent = ExtractTodoContent(lines[i]);
                        todos.Add($"{relativePath} - Line {i + 1}|{todoContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions encountered during file processing (e.g., permission issues, invalid file format)
                Logger.LogException(filePath, ex);
            }

            return todos;
        }

        /// <summary>
        /// Extracts the content of a TODO comment from a line of code.
        /// </summary>
        /// <param name="line">The line of code containing the TODO comment.</param>
        /// <returns>The extracted TODO content.</returns>
        private static string ExtractTodoContent(string line)
        {
            const string singleLineTodo = "// TODO:";
            const string multiLineTodo = "/* TODO:";

            if (line.Contains(singleLineTodo))
            {
                return line.Substring(line.IndexOf(singleLineTodo) + singleLineTodo.Length).Trim();
            }
            if (line.Contains(multiLineTodo))
            {
                return line.Substring(line.IndexOf(multiLineTodo) + multiLineTodo.Length).Trim();
            }

            return line.Trim();
        }

        /// <summary>
        /// Calculates the relative path of a file with respect to a base directory.
        /// </summary>
        /// <param name="basePath">The base directory path.</param>
        /// <param name="fullPath">The full path of the file.</param>
        /// <returns>The relative path from the base directory to the file.</returns>
        private static string GetRelativePath(string basePath, string fullPath)
        {
            var baseUri = new Uri(basePath.EndsWith("\\") ? basePath : basePath + "\\");
            var fullUri = new Uri(fullPath);
            return baseUri.MakeRelativeUri(fullUri).ToString().Replace('/', '\\');
        }
    }
}
