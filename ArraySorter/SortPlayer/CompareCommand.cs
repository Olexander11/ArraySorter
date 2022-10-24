using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraySorter.SortPlayer
{
    internal class CompareCommand : Command
    {
        public CompareCommand(DataGridView grid, (int, int) firstPoint, (int, int) secondPoint)
        {
            this.grid = grid;
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
        }
        private DataGridView grid;
        private (int, int) firstPoint;
        private (int, int) secondPoint;
        public override void Play()
        {
            grid.Rows[firstPoint.Item1].Cells[firstPoint.Item2].Style.BackColor = Color.Green;
            grid.Rows[secondPoint.Item1].Cells[secondPoint.Item2].Style.BackColor = Color.Green;

        }
    }
}
