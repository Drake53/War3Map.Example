// ------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Drake53">
// Copyright (c) 2019 Drake53. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// ------------------------------------------------------------------------------

using static War3Api.Common;

namespace War3Map.Example.Source
{
    internal static class Program
    {
        private static void Main()
        {
            TimerStart(CreateTimer(), 1f, false, HelloWorld);
        }

        private static void HelloWorld()
        {
            DestroyTimer(GetExpiredTimer());
            BlzDisplayChatMessage(Player(0), 0, "Hello World!");
        }
    }
}