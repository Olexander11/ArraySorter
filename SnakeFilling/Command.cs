namespace SnakeFilling
{
    internal abstract class Command
    {
        public abstract List<(int, int)> Execute();
    }

    enum ComandType
    {
        left,
        right,
        down,
        up,
        right_up,
        left_down,
        none
    }

}
