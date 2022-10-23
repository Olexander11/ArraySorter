using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraySorter.Controls
{
    public partial class RandomArrayControl : UserControl, ISourceControl
    {
        public RandomArrayControl()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> ArrayComplit;
        private int[,] array = null;

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            CreateArray();
        }

        private async void CreateArray()
        {
           Task task = Task.Run (() => {
                array = new int[(int)xNumericUpDown.Value, (int)yNumericUpDown.Value];
                Random random = new Random();
                for (int i = 1; i <= (int)xNumericUpDown.Value; i++)
                {
                    for (int j = 1; j <= (int)yNumericUpDown.Value; j++)
                    {
                        array[i, j] = random.Next(1, 1000);
                    }
                }
            });
            await task;
            ArrayComplit?.Invoke(this, EventArgs.Empty);
        }

        public int[,] GetArray()
        {
            return array;
        }
    }
}
