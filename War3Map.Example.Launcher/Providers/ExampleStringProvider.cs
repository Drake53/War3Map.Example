// ------------------------------------------------------------------------------
// <copyright file="ExampleStringProvider.cs" company="Drake53">
// Copyright (c) 2019 Drake53. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// ------------------------------------------------------------------------------

namespace War3Map.Example.Launcher
{
    internal sealed class ExampleStringProvider : StringProvider
    {
        /// <summary>
        /// Path to the input .w3x file or folder.
        /// This base map is expected to at least contain a war3map.w3i and a war3map.w3e file.
        /// However, you can update <see cref="Program"/> to create the war3map.w3i file from scratch.
        /// </summary>
        public override string BaseMapFilePath => throw new System.NotImplementedException();

        /// <summary>
        /// Path to a directory containing additional files to be imported.
        /// Meant to replace World Editor's import manager.
        /// This property is optional, and can be set to null.
        /// </summary>
        public override string AssetsDirectoryPath => base.AssetsDirectoryPath;

        /// <summary>
        /// Directory in which the build files will be created, including the new .w3x file.
        /// </summary>
        public override string OutputDirectoryPath => base.OutputDirectoryPath;

        /// <summary>
        /// Path to Warcraft III.exe.
        /// </summary>
        public override string Warcraft3ExecutablePath => throw new System.NotImplementedException();
    }
}