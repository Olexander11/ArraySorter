namespace SpiralFilling
{
    internal abstract class Command
    {
        public abstract List<(int, int)> Execute();
    }

    enum ComandType {
    left,
    right,
    down,
    up,
    none
    }

}
