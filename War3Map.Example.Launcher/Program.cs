// ------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Drake53">
// Copyright (c) 2019 Drake53. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// ------------------------------------------------------------------------------

using System.Diagnostics;
using System.IO;

using War3Net.Build;
using War3Net.Build.Script;

namespace War3Map.Example.Launcher
{
    internal static class Program
    {
        private static void Main()
        {
            // Configuration
            var scriptBuilderOptions = new ScriptBuilderOptions();
            // TODO: set map name and description (note: game reads these from the .w3i file, so changing these doesn't really do anything)
            scriptBuilderOptions.MapName = "Just Another Warcraft III Map";
            scriptBuilderOptions.MapDescription = "Source code generated with CSharp.lua\r\nMap generated with War3Net.Build";
            // TODO: set player slots
            scriptBuilderOptions.PlayerSlots.Add(new PlayerSlot(0f, 0f, 0, true));
            scriptBuilderOptions.PlayerSlots.Add(new PlayerSlot(0f, 0f, 1, false));

            var scriptCompilerOptions = new ScriptCompilerOptions();
            scriptCompilerOptions.BuilderOptions = scriptBuilderOptions;
            // TODO: rename project(s)?
            scriptCompilerOptions.SourceDirectory = @"..\..\..\..\War3Map.Example.Source";
            // TODO: set output directory
            scriptCompilerOptions.OutputDirectory = @"";

            // TODO: set path to Warcraft III.exe
            var wc3executablePath = @"";
            // TODO: optionally customize commandline args
            var wc3executableArguments = "-nowfpause -graphicsapi Direct3D9 ";

            // Build and launch
            var mapName = "TestMap.w3x";
            var mapBuilder = new MapBuilder(mapName);

            // TODO: set path(s) to load assets (this can be a .w3m/.w3x file, or a directory)
            if (mapBuilder.Build(scriptCompilerOptions, @"", @""))
            {
                var mapPath = Path.Combine(scriptCompilerOptions.OutputDirectory, mapName);
                Process.Start(wc3executablePath, $"{wc3executableArguments} -loadfile \"{mapPath}\"");
            }
        }
    }
}