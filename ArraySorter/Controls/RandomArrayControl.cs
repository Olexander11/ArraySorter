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

            confirmButton.Click += ConfirmButton_Click;
        }

        public event EventHandler<EventArgs> ArrayComplit;
        private int[,] array = null;

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            CreateArray();
        }

        private void CreateArray()
        {
                array = new int[(int)xNumericUpDown.Value, (int)yNumericUpDown.Value];
                Random random = new Random();
                for (int i = 0; i < (int)xNumericUpDown.Value; i++)
                {
                    for (int j = 0; j < (int)yNumericUpDown.Value; j++)
                    {
                        array[i, j] = random.Next(1, 1000);
                    }
                }

            ArrayComplit?.Invoke(this, EventArgs.Empty);
        }

        public int[,] GetArray()
        {
            return array;
        }
    }
}
