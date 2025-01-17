# Todo Log Generator Program User Guide

## Introduction to Todo Log Generator

The **Todo Log Generator** is a program designed to help users scan a selected directory for **TODO comments** in source code files. The program scans through all files in the selected directory (and its subdirectories), extracts lines containing TODO comments, and generates a log of these comments.  

The generated log can be viewed within the program and is saved as a text file in the same directory as the program.

## 1. Installing and Running the Program

### 1.1 Downloading the Program
- Download the provided [TodoLogGenerator.zip](./TodoLogGenerator.zip) file from this repository.
- Save the downloaded file to a folder of your choice.
- Extract the contents of the **`TodoLogGenerator.zip`** file.

### 1.2 Folder Setup
- The program requires the following folder:
  - **`Logs` folder**: This folder will automatically be created when the program is first run. It will store the generated log files.

### 1.3 Running the Program
- After extracting the contents of the zip file, navigate to the folder where you extracted the files.
- Double-click on **`TodoLogGenerator.exe`** to run the program.

## 2. How to Use the Program

### 2.1 Selecting a Directory
1. Upon opening the program, click the **"Select Directory"** button to choose the directory you want to scan for TODO comments.
2. The program will allow you to browse your computer and select the folder to scan.
3. The selected folder path will be displayed in the label below the button.

### 2.2 Generating the Log
1. Once you have selected the directory, click on the **"Generate Log"** button to begin scanning the selected directory and its subdirectories for files that contain TODO comments.
2. The program will search through all files in the selected folder and its subdirectories, excluding files with extensions like `.exe`, `.dll`, `.log`, etc.
3. All TODO comments found will be listed in the text area on the right side of the window.

### 2.3 Stopping the Process
1. If you wish to cancel the scanning process before it completes, click the **"Stop"** button.
2. The scanning process will halt, and any operation in progress will be canceled.

### 2.4 Saving the Log
1. After the scanning is complete, you can save the generated TODO log by clicking the **"Save Log"** button.
2. The log will be saved as a `.txt` file in the **`Logs`** folder.
3. The file name will be based on the directory name and will include the suffix `_TODOLog.txt`.
   - Example: `development_TODOLog.txt`

### 2.5 Log Format
The TODO log will be displayed in the following format:
```css
[relative-path-to-file - Line X] TODO content
```

Where:
- `relative-path-to-file` is the path relative to the selected directory.
- `Line X` indicates the line number where the TODO comment is located.
- `TODO content` is the actual TODO comment text.

## 3. Troubleshooting

### 3.1 No Directory Selected
- **Error Message**: "Please select a directory first."
  
  **Solution**:
  - Ensure that you have selected a directory before clicking "Generate Log."
  
### 3.2 No TODO Comments Found
- **Error Message**: "No TODOs found in the selected directory."
  
  **Solution**:
  - Check the directory to ensure that it contains source code files with TODO comments. Make sure the files have the correct format for TODO comments (e.g., `// TODO:` or `/* TODO:`).

### 3.3 Operation Cancellation
- **Error Message**: "Operation cancelled by user."
  
  **Solution**:
  - If you manually stop the process, this message will appear. It indicates that the scanning process was successfully halted.

### 3.4 Log File Not Saving
- **Error Message**: "An error occurred while saving the log."
  
  **Solution**:
  - Ensure that the program has write access to the `Logs` folder.
  - Check for any security software or system permissions that might block file creation.
  - If the `Logs` folder is not found, try deleting the folder and re-running the program.

## 4. FAQs

### How can I make sure my files are scanned correctly?
- Ensure that the files you want to scan have the correct extensions (excluding files like `.exe` and `.dll`).
- Only text-based files (such as `.cs`, `.txt`, etc.) will be processed for TODO comments.

### Can I scan a network drive?
- Yes, as long as the network drive is accessible from your computer, you can select it as the directory to scan.

### How can I check which TODO comments were found?
- After generating the log, all TODO comments found within the files will be displayed in the text box in the program window.
- You can also save the log to a text file for further reference.

## 5. Contact and Support

If you encounter any issues while using the program, please contact support with the following details:
- The directory path you are trying to scan.
- Any error messages or issues encountered.

**Email Support**: potterLim0808@gmail.com
