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
                    await comand.Play(speed);
                    if (_stoped)
                        break;
                    while (_paused)
                    {
                        await Task.Delay(speed);
                        if (_stoped)
                            break;
                    }
                }
            MovieStoped?.Invoke(this, EventArgs.Empty);
        }

        public void Stop()
        {
            _stoped = true;
        }

        bool _stoped = false;
        bool _paused = false;
        public void Pause()
        {
            _paused = true;
        }

        public void Continue()
        {
            _paused = false;
        }

        public void Clear()
        {
            commands.Clear();
        }

    }
}
