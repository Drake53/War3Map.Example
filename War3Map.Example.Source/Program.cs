// ------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Drake53">
// Copyright (c) 2019 Drake53. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// ------------------------------------------------------------------------------

using System;

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

    public sealed class Message : IDisposable
    {
        public const int RECIPIENT_ALL = 0;
        public const int RECIPIENT_ALLIES = 1;
        public const int RECIPIENT_OBSERVERS = 2;
        public const int RECIPIENT_PRIVATE = 3;

        private readonly timer _timer;
        private readonly player _player;
        private readonly int _recipient;
        private readonly string _message;

        private bool _timerRunning;
        private bool _disposing;

        public Message(player player, int recipient, string message)
        {
            _timer = CreateTimer();
            _player = player;
            _recipient = recipient;
            _message = message;

            _timerRunning = false;
            _disposing = false;
        }

        public void Display(float timeout)
        {
            _timerRunning = true;
            TimerStart(_timer, timeout, false, OnDisplay);
        }

        public void Dispose()
        {
            if (!_timerRunning)
            {
                // PauseTimer(_timer);
                DestroyTimer(_timer);
            }
            else
            {
                _disposing = true;
            }
        }

        private void OnDisplay()
        {
            _timerRunning = false;
            BlzDisplayChatMessage(_player, _recipient, _message);

            if (_disposing)
            {
                Dispose();
            }
        }
    }
}