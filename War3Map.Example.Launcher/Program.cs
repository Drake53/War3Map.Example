// ------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Drake53">
// Copyright (c) 2019 Drake53. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// ------------------------------------------------------------------------------

using System.Diagnostics;
using System.IO;

using War3Net.Build;
using War3Net.Build.Providers;
using War3Net.Build.Script;
using War3Net.IO.Mpq;

namespace War3Map.Example.Launcher
{
    /// <summary>
    /// To get started, update the following:
    /// In <see cref="ExampleStringProvider"/>: update the paths and strings.
    /// In <see cref="PlayerAndForceProperties"/>: update player and force properties.
    /// In <see cref="Source.Program"/>: write the map script.
    /// Optionally, you can further customize the properties of mapInfo in this class.
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            var stringProvider = new ExampleStringProvider();

            var mapInfo = MapInfo.Parse(FileProvider.GetFile(Path.Combine(stringProvider.BaseMapFilePath, MapInfo.FileName)));
            mapInfo.MapName = stringProvider.MapName;
            mapInfo.MapDescription = stringProvider.MapDescription;
            mapInfo.MapAuthor = stringProvider.MapAuthor;
            mapInfo.RecommendedPlayers = stringProvider.RecommendedPlayers;

            mapInfo.MapFlags &= ~MapFlags.MeleeMap;
            mapInfo.ScriptLanguage = ScriptLanguage.Lua;

            PlayerAndForceProperties.ApplyToMapInfo(mapInfo);

            var scriptCompilerOptions = new ScriptCompilerOptions();
            scriptCompilerOptions.MapInfo = mapInfo;
            scriptCompilerOptions.LobbyMusic = stringProvider.LobbyMusic;
            scriptCompilerOptions.SourceDirectory = stringProvider.SourceProjectPath;
            scriptCompilerOptions.OutputDirectory = stringProvider.OutputDirectoryPath;

            // Note: do not use compression, as it is currently bugged.
            scriptCompilerOptions.DefaultFileFlags = MpqFileFlags.Exists;
            scriptCompilerOptions.FileFlags["war3map.wtg"] = 0;
            scriptCompilerOptions.FileFlags[mapInfo.ScriptLanguage == ScriptLanguage.Jass ? "war3map.lua" : "war3map.j"] = 0;
            scriptCompilerOptions.FileFlags[ListFile.Key] = MpqFileFlags.Exists | MpqFileFlags.Encrypted | MpqFileFlags.BlockOffsetAdjustedKey;

            // Build and launch
            var mapName = stringProvider.MapFileName;
            var mapBuilder = new MapBuilder(mapName);

            if (mapBuilder.Build(scriptCompilerOptions, stringProvider.AssetsDirectoryPath, stringProvider.BaseMapFilePath))
            {
                var mapPath = Path.Combine(scriptCompilerOptions.OutputDirectory, mapName);
                Process.Start(stringProvider.Warcraft3ExecutablePath, $"{stringProvider.CommandLineArguments} -loadfile \"{mapPath}\"");
            }
        }
    }
}