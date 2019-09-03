## War3Map.Example
### Simple launcher to build a C# warcraft III map project from within visual studio.

## Requirements

- [CSharp.lua](https://github.com/Drake53/CSharp.lua)
- [War3Net](https://github.com/Drake53/War3Net)
- [Visual Studio](https://visualstudio.microsoft.com/vs/)

## Setup

- Clone CSharp.lua, War3Net, and this repository.
    - Make sure the project directories share the same root directory, and are named "CSharp.lua" and "War3Net", so that .csproj dependencies can be resolved.
- Create a new warcraft III map, or use an existing map.
    - Make sure the script language is set to 'lua'.
    - Save the map either as folder (recommended), or as file.
- Edit Program.cs in War3Map.Example.Launcher.
    - Update map name and description.
    - Set player slots.
    - If you decide to rename the War3Map.Example projects, update the source directory to match the new name.
    - Set the output directory to wherever you like (this will contain the listfile, lua source code, and .w3x files).
    - Set the path to your warcraft III executable, and optionally change the arguments.
    - Set the paths to load assets. It is recommended to use two paths.
        - One path will load the files from your .w3m or .w3x file or folder.
        - The other path can be used to add imports (to replace the World Editor's import manager).
        - Note that when there are coflicting file paths, the first file added will be used. For this reason, it's recommended to set the .w3m/.w3x as last argument.
- Run the code in visual studio, and make sure War3Map.Example.Launcher is set as startup project.
    - When Warcraft III launches, you should see the message "Hello World!" appear after one second.
- Now that everything seems to be working, you can start editing the code in War3Map.Example.Source.
