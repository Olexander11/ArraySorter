using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArraySorter.SortPlayer
{
    internal class Invoker
    {
        List<Command> commands;
        int speed = 1;
        public int Speed
        {
            get => speed;
            set
            {
                lock (speedLock)
                {
                    if (value <= 1)
                        speed = 1;
                    else if (value >= 60 * 1000)
                        speed = 60 * 1000;
                    else
                        speed = value;
                }
            }
        }

        private readonly object speedLock = new object();
        public Invoker(int speed)
        {
            this.speed = speed;
        }

        public void SetCommand(Command c)
        {
            commands.Add(c);
        }

        public void Run()
        {
            if (commands != null && commands.Any())
                foreach (Command comand in commands)
                {
                    comand.Play();
                    lock (speedLock)
                    {
                        Thread.Sleep(speed);
                    }
                }
        }

        public void Clear()
        {
            commands.Clear();
        }

    }
}
