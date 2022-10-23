namespace SnakeFilling
{
    internal class SchemeBuilder
    {
        ArrayMover arrayMover = new ArrayMover();
        List<Command> commands = new List<Command>();

        public void GreateSchema(int rows, int columns)
        {
            int currentRow = rows - 1;
            int currentColumn = columns - 1;
            {
                Command command;
                while (currentRow != rows && currentColumn != columns)
                {
                    if (currentColumn == columns)
                    {
                        command = new CommandExecutor(arrayMover, ComandType.down, 1);
                        commands.Add(command);
                        currentRow++;
                    }
                    else
                    {
                        command = new CommandExecutor(arrayMover, ComandType.right, 1);
                        commands.Add(command);
                        currentColumn++;
                    }

                    command = new CommandExecutor(arrayMover, ComandType.left_down, currentColumn -1);
                    commands.Add(command);
                    currentRow += currentColumn - 1;
                    currentColumn = 1;

                    if (currentRow == rows)
                    {
                        command = new CommandExecutor(arrayMover, ComandType.right, 1);
                        commands.Add(command);
                        currentColumn++;
                    }
                    else
                    {
                        command = new CommandExecutor(arrayMover, ComandType.down, 1);
                        commands.Add(command);
                        currentRow++;
                    }

                    command = new CommandExecutor(arrayMover, ComandType.right_up, currentRow - 1);
                    commands.Add(command);
                    currentColumn += currentRow - 1;
                    currentRow = 1;
                }
            }
        }

        public List<(int, int)> GetMoves()
        {
            List<(int, int)> result = new List<(int, int)>();
            if (commands.Any())
            {
                foreach (Command command in commands)
                {
                    result.AddRange(command.Execute());
                }
            }
            return result;
        }
    }
}
