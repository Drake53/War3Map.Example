using System;

using War3Lib.Extensions.Common;

using static War3Api.Common;

namespace War3Map.Example.Source.Dependency
{
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
            _timer.Start(timeout, false, OnDisplay);
        }

        public void Dispose()
        {
            if (!_timerRunning)
            {
                // PauseTimer(_timer);
                DestroyTimer(_timer);
#if DEBUG
                DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "[Debug] Timer destroyed.");
#endif
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