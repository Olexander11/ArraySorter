﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralRoute
{
    internal class CommandExecutor : Command
    {
        ComandType comandType;
        int steps;
        ArrayMover mover;

        public CommandExecutor(ArrayMover mover,
            ComandType comandType, int steps)
        {
            this.mover = mover;
            this.comandType = comandType;
            this.steps = steps;
        }

        public ComandType ComandType
        {
            set { comandType = value; }
        }

        public int Steps
        {
            set { steps = value; }
        }


        public override IEnumerable<(int, int)> Execute()
        {
            return mover.Move(comandType, steps);
        }
    }
}