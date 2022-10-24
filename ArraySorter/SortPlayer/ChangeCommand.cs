using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraySorter.SortPlayer
{
    internal class ChangeCommand : Command
    {
        public ChangeCommand(DataGridView grid, (int, int) firstPoint, (int, int) secondPoint)
        {
            this.grid = grid;
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
        }
        private DataGridView grid;
        private (int, int) firstPoint;
        private (int, int) secondPoint;
        public override async void Play(int sleep)
        {
            grid.Rows[firstPoint.Item1].Cells[firstPoint.Item2].Style.BackColor = Color.Red;
            grid.Rows[secondPoint.Item1].Cells[secondPoint.Item2].Style.BackColor = Color.Red;
            object temtNum = grid.Rows[firstPoint.Item1].Cells[firstPoint.Item2].Value;
            grid.Rows[firstPoint.Item1].Cells[firstPoint.Item2].Value = grid.Rows[secondPoint.Item1].Cells[secondPoint.Item2].Value;
            grid.Rows[secondPoint.Item1].Cells[secondPoint.Item2].Value = temtNum;

            await Task.Delay(sleep);
            grid.Rows[firstPoint.Item1].Cells[firstPoint.Item2].Style.BackColor = Color.White;
            grid.Rows[secondPoint.Item1].Cells[secondPoint.Item2].Style.BackColor = Color.White;
        }
    }
}
