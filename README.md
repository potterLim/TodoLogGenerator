# Todo Log Generator

The **Todo Log Generator** is a utility designed to help users scan a selected directory for **TODO comments** in source code files. It scans through all files in the chosen directory (and its subdirectories), extracts lines containing TODO comments, and generates a log of these comments.

The program is developed in **Windows Forms** with C# and .NET Framework 4.7.2, and the generated log can be viewed within the program and saved as a text file in the same directory as the program.

## Key Features

- **TODO Comments Scanning**  
  Scans through all files in the selected directory and its subdirectories, excluding certain file types like `.exe`, `.dll`, `.log`, etc.
  
- **Log Generation**  
  Extracts **TODO comments** and generates a log file containing these comments, formatted with relative file paths and line numbers.

- **Stop Processing**  
  Allows users to stop the scanning process if needed, halting the operation gracefully.

- **Log Saving**  
  The log file can be saved as a `.txt` file in the **`Logs`** folder. The file name includes the directory name and a `_TODOLog.txt` suffix.

## Detailed Implementation

### 1. Class and File Structure

- **FileProcessor**: Handles file-related tasks, including fetching files and extracting TODO comments from them.
  - `GetFilesFromDirectory`: Scans the directory for files while excluding certain file extensions.
  - `ExtractTodosFromFile`: Extracts TODO comments from each file, returning the relative path, line number, and TODO content.
  
- **Logger**: Handles logging of exceptions that occur during file processing. Errors are logged in the **`Logs`** folder with detailed information about the exception.

- **MainForm**: Implements the UI and controls the workflow of the application. Users can select a directory, generate the TODO log, stop the operation, and save the log file.

### 2. How the Application Works

- **Directory Selection**: The user selects a directory through the "Select Directory" button. This directory is scanned recursively, and all files (excluding `.exe`, `.dll`, etc.) are processed.

- **Scanning Process**: When the user clicks "Generate Log," the program starts scanning the directory for TODO comments. The process can be stopped at any time by clicking the "Stop" button.

- **Log Generation and Saving**: Once the scanning process completes, the user can save the generated log to a `.txt` file. The log contains lines formatted as follows:
  
  ```css
  [relative-path-to-file - Line X] TODO content
  ```

### 3. Error Handling

- **Exceptions**: The program is designed to handle various exceptions gracefully, such as access denied issues, file reading errors, and invalid directory paths. These errors are logged in an error file within the Logs folder.

- **Cancellation**: If the user clicks the "Stop" button during scanning, the process is canceled, and a message indicating the cancellation is shown.

### 4. UI Design and Interaction

The UI consists of the following components:

- **Directory Selection**: A button for selecting the directory to scan.
- **Log Generation**: A button to start the scan and generate the TODO log.
- **Stop Button**: A button that allows the user to cancel the scan.
- **TextBox**: Displays the scanning progress and any generated TODO comments.
- **Save Log**: A button to save the generated log into a `.txt` file.

### 5. Requirements

- **Development Environment**: Visual Studio 2022
- **.NET Framework**: 4.7.2

### 6. Compilation

To compile the program manually, follow these steps:

1. Open the project in Visual Studio 2022.
2. Set the build configuration to Release.
3. Build the project, and the output executable will be created in the `bin/Release` directory.

## Contributing

To contribute to **Todo Log Generator**, follow these steps:

1. Fork the Repository

    Create a fork of the repository under your GitHub account.

2. Create a Branch

    Create a new branch for your feature:

    ```bash
    git checkout -b feature/your-feature-name
    ```

3. Make Changes and Test

    Implement the feature or bug fix and test it to ensure it does not break existing functionality.

4. Commit and Push

    Write a descriptive commit message and push the changes:

    ```bash
    git commit -m "Describe the changes"
    git push origin feature/your-feature-name
    ```

5. Submit a Pull Request

    Open a pull request on GitHub, providing a clear explanation of your changes.

## Contact and Support

If you encounter any issues while using the program, please reach out for support:

1. GitHub Issues

    Use the Issues section in the GitHub repository to report bugs or suggest new features.

2. Email Support

    For further assistance, you can email support at: potterLim0808@gmail.com