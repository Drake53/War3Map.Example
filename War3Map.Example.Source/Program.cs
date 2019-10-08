// ------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Drake53">
// Copyright (c) 2019 Drake53. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// ------------------------------------------------------------------------------

using War3Map.Example.Source.Dependency;

using static War3Api.Common;

namespace War3Map.Example.Source
{
    internal static class Program
    {
        private static void Main()
        {
            using (var msg = new Message(Player(0), Message.RECIPIENT_ALL, "Hello World!"))
            {
                msg.Display(1f);
            }
        }
    }
}