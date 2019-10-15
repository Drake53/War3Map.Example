// ------------------------------------------------------------------------------
// <copyright file="StringProvider.cs" company="Drake53">
// Copyright (c) 2019 Drake53. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// ------------------------------------------------------------------------------

namespace War3Map.Example.Launcher
{
    internal abstract class StringProvider
    {
        public virtual string MapFileName => $"{MapName}.w3x";

        public virtual string MapName => @"Just Another Warcraft III Map";

        public virtual string MapDescription => @"Source code generated with CSharp.lua\r\nMap generated with War3Net.Build";

        public virtual string MapAuthor => @"Unknown";

        public virtual string RecommendedPlayers => @"Any";

        public virtual string SourceProjectPath => @"..\..\..\..\War3Map.Example.Source";

        public virtual string CommandLineArguments => @"-nowfpause -graphicsapi Direct3D9 ";

        public virtual string LobbyMusic => null;

        public abstract string BaseMapFilePath { get; }

        public virtual string AssetsDirectoryPath => @".\Assets";

        public virtual string OutputDirectoryPath => @"..\..\..\..\artifacts";

        public abstract string Warcraft3ExecutablePath { get; }
    }
}