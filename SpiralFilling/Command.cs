namespace SpiralFilling
{
    internal abstract class Command
    {
        public abstract IEnumerable<(int, int)> Execute();
    }

    enum ComandType {
    left,
    right,
    down,
    up,
    none
    }

}
