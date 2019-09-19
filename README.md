## War3Map.Example
### Simple launcher to build a C# warcraft III map project from within visual studio.

## Requirements

- [CSharp.lua](https://github.com/Drake53/CSharp.lua)
- [War3Net](https://github.com/Drake53/War3Net)
- [Visual Studio](https://visualstudio.microsoft.com/vs/)

## Setup

- Clone [CSharp.lua](https://github.com/Drake53/CSharp.lua), [War3Net](https://github.com/Drake53/War3Net), and this repository.
    - Make sure the project directories share the same root directory, and are named "CSharp.lua" and "War3Net", so that .csproj dependencies can be resolved.
- Create a new warcraft III map, or use an existing map.
    - Save the map either as folder (recommended), or as file.
- Edit the strings in War3Map.Example.Launcher.ExampleStringProvider accordingly.
- Run the code in visual studio, with War3Map.Example.Launcher as startup project, to make sure everything is working.
    - When Warcraft III launches, you should see the message "Hello World!" appear after one second.
- Now that everything seems to be working, you can start editing the code in War3Map.Example.Source.
    - You can also update the player and force settings in War3Map.Example.LauncherPlayerAndForceProperties.
