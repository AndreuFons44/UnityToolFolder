﻿# Unity Folder Structure Creator

## Description

This Unity Editor tool allows you to create folder structures in your Unity project based on provided data. The tool provides a user interface within the Unity Editor to select a folder structure file, preview the structure, and create folders.

## Features

- **Menu Item:** Access the tool through the Unity Editor menu at "EditorTool/Create Folder Structure."
- **Preview:** View a preview of the folder structure, indicating whether each folder already exists in the project.

## Installation

### Manual Installation

1. Clone or download this repository.
2. Copy the `ToolFolder` folder into your Unity project's `Assets` directory.

### Package Installation

1. Download the `ToolFolderPack.unitypackage` from the releases.
2. In Unity, go to "Assets" -> "Import Package" -> "Custom Package..."
3. Select the downloaded `ToolFolderPack.unitypackage` file and click "Open."

## How to Use

1. Open the Unity Editor.
2. Go to the "EditorTool" menu.
3. Select "Create Folder Structure" to open the tool window.
4. In the tool window:
   - **Select Folder Structure File:** Use the provided field to select a `SCO_FolderStructure` asset.
   - **Preview:** Observe a preview of the folder structure.
   - **Create Folders:** Click the "Create Folders" button to create the specified folder structure in your Unity project.
![Exemple 1](https://github.com/AndreuFons44/UnityToolFolder/blob/main/Example1.PNG?raw=true)

## How to Create a Folder Structure

1. Select "Create" -> "ToolFolder" -> "Folder Structure" from the context menu.
2. This will create a new folder structure file in the selected folder. You can rename it as needed.
3. Click the "+" button to add a new element to the array.
4. Configure the new element with a main folder name and, if necessary, subfolder names.
![Exemple 2](https://github.com/AndreuFons44/UnityToolFolder/blob/main/Example2.PNG?raw=true)
