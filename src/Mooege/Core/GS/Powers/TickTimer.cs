﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mooege.Core.GS.Powers
{
    public class TickTimer
    {
        public int TimeoutTick;
        private Game.Game _game;

        public TickTimer(Game.Game game, int timeoutTick)
        {
            _game = game;
            TimeoutTick = timeoutTick;
        }

        public bool TimedOut()
        {
            return _game.Tick >= TimeoutTick;
        }
    }

    public class TickRelativeTimer : TickTimer
    {
        public TickRelativeTimer(Game.Game game, int ticks)
            : base(game, game.Tick + ticks)
        {
        }
    }

    public class TickSecondsTimer : TickRelativeTimer
    {
        const float TicksPerSecond = 60; // Game currently doesn't expose the tick increment rate

        public TickSecondsTimer(Game.Game game, float seconds)
            : base(game, (int)(TicksPerSecond * seconds))
        {
        }
    }
}
