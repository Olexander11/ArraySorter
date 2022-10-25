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
        List<Command> commands = new List<Command>();
        int speed = 1000;
        public int Speed
        {
            get => speed;
            set
            {
                if (value <= 1)
                    speed = 1;
                else if (value >= 60 * 1000)
                    speed = 60 * 1000;
                else
                    speed = value;
            }
        }

        public event EventHandler MovieStoped;
        public Invoker(int speed)
        {
            this.speed = speed;
        }

        public void SetCommand(Command c)
        {
            commands.Add(c);
        }

        public async void Run()
        {
            if (commands != null && commands.Any())
                foreach (Command comand in commands)
                {
                    comand.Play(speed);
                    await Task.Delay(speed);
                }
            MovieStoped?.Invoke(this, EventArgs.Empty);
        }

        public void Clear()
        {
            commands.Clear();
        }

    }
}
