namespace SnakeFilling
{
    internal abstract class Command
    {
        public abstract IEnumerable<(int, int)> Execute();
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
