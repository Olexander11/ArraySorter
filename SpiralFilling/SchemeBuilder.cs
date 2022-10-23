namespace SpiralFilling
{
    internal class SchemeBuilder
    {
        ArrayMover arrayMover = new ArrayMover();
        List<Command> commands = new List<Command>();

        public void GreateSchema(int rows, int columns)
        {
            int usedCells = 1;
            int currentRow = rows - 1;
            int currentColumn = columns - 1;
            bool firstLoop = true; 
            {
                Command command;
                while (usedCells <= rows * columns)
                {
                    command = new CommandExecutor(arrayMover, ComandType.right, currentColumn);
                    usedCells += currentColumn;
                    if (!firstLoop)
                        currentColumn--;
                    commands.Add(command);
                    command = new CommandExecutor(arrayMover, ComandType.down, currentRow);
                    usedCells += currentRow;
                    currentRow--;
                    commands.Add(command);
                    command = new CommandExecutor(arrayMover, ComandType.left, currentColumn);
                    usedCells += currentColumn;
                    currentColumn--;
                    commands.Add(command);
                    command = new CommandExecutor(arrayMover, ComandType.up, currentColumn);
                    usedCells += currentRow;
                    currentRow--;
                    commands.Add(command);
                }
            }
        }

        public List<(int, int)> GetMoves()
        {
            List <(int, int)> result = new List<(int, int) >();
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
