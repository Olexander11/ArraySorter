using ArraySorter.ArrayCreator.FileCreator;
using ArraySorter.Controls;
using ArraySorter.DllLoader;
using ArraySorter.Models;
using ArraySorter.Models.ArrayModel;
using ArraySorter.SortPlayer;
using CommonInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ArraySorter
{
    public partial class ArrayDesk : Form
    {
        public ArrayDesk()
        {
            InitializeComponent();
            sortMethodComboBox.DataSource = DllDirectoryLoader.LoadSorters();
            orderComboBox.DataSource = DllDirectoryLoader.LoadOrders();
            EnableSortingProcess(false);
            using (SortedArrayContext db = new SortedArrayContext())
            {
                var source = new BindingSource();
                source.DataSource = db.SortedArrays.OrderBy(a => a.SortingStart).ToList();
                sortingProcessDataGridView.DataSource = source;  
            }
            invoker = new Invoker(500);
            invoker.MovieStoped += Invoker_MovieStoped;
            processGridView.ReadOnly = true;
            processGridView.ColumnHeadersVisible = false;
            processGridView.RowHeadersVisible = false;
            processGridView.AllowUserToAddRows = false;
            ArraySourceSelected(true);
            sortingProcessLabel.Text = "Sorting process.";
            sortButton.Click += SortButton_Click;
            updateHistoryButton.Click += UpdateHistoryButton_Click;
            fileRadioButton.CheckedChanged += FileRadioButton_CheckedChanged;
            ramdomRadioButton.CheckedChanged += RandomRadioButton_CheckedChanged;
            confirmMethodButton.Click += ConfirmMethodButton_Click;
            startSortingButton.Click += StartSortingButton_Click;
            speedUpButton.Click += SpeedUpButton_Click;
            speedDownButton.Click += SpeedDownButton_Click;

            Logger.Logger logger = Logger.Logger.getInstance();
        }

        private void Invoker_MovieStoped(object sender, EventArgs e)
        {
            DisableSelectSourseControls(false);
            sortingProcessLabel.Text = "Sorting ended.";
        }

        private int[,] array = null;
        private ISorter sorter = null;
        private IOrder order = null;
        private bool sortHistoryByAsc = true;
        private Invoker invoker;
        private Logger.Logger logger;
        private void UpdateHistoryButton_Click(object sender, EventArgs e)
        {
            UpdateHistoryGreed();
        }


        private void SortButton_Click(object sender, EventArgs e)
        {
            sortHistoryByAsc = !sortHistoryByAsc;
            UpdateHistoryGreed();
        }

        private void UpdateHistoryGreed()
        {
            using (SortedArrayContext db = new SortedArrayContext())
            {
                var source = new BindingSource();     
                if (sortHistoryByAsc)
                    source.DataSource = db.SortedArrays.OrderBy(a => a.SortingStart).ToList();
                else
                    source.DataSource = db.SortedArrays.OrderByDescending(a => a.SortingStart).ToList();

                sortingProcessDataGridView.DataSource = source;
            }
            sortingProcessDataGridView.Update();
        }

        private void RandomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ramdomRadioButton.Checked)
            {
                fileRadioButton.Checked = false;
                ArraySourceSelected(true);
            }
            else
            {
                fileRadioButton.Checked = true;
            }
        }

        private void FileRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (fileRadioButton.Checked)
            {
                ramdomRadioButton.Checked = false;
                ArraySourceSelected(false);
            }
            else
            {
                ramdomRadioButton.Checked = true;
            }
        }

        private void ArraySourceSelected(bool isRandom)
        {
            sortingProcessLabel.Text = "Sorting process.";
            arraySourcePanel.SuspendLayout();
            arraySourcePanel.Controls.Clear();
            Control control = null;
            if (isRandom)
            {
                control = new RandomArrayControl();
            }
            else
            {
                control = new FileSourseControl();
            }
            control.Invalidate();
            arraySourcePanel.Controls.Add(control);
            arraySourcePanel.ResumeLayout();
            (control as ISourceControl).ArrayComplit += ArrayDesk_ArrayComplit;
        }

        private void ArrayDesk_ArrayComplit(object sender, EventArgs e)
        {
            if (sender is ISourceControl source)
            {
                array = source.GetArray();
                processGridView.Rows.Clear();
                int arrayRow = array.GetLength(0);
                int arrayColumn = array.GetLength(1);

                //string message = $"Selectede Array {arrayRow}X{arrayColumn}.";
                //logger.Log(message);

                processGridView.ColumnCount = arrayColumn;

                for (int r = 0; r < arrayRow; r++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.processGridView);
                    
                    for (int c = 0; c < arrayColumn; c++)
                    {
                        row.Cells[c].Value = array[r, c];
                    }                  

                    processGridView.Rows.Add(row);
                }
                foreach(object col in processGridView.Columns)
                {
                    DataGridViewColumn column = col as DataGridViewColumn;
                    column.Width = processPanel.Width / arrayColumn;
                }

                processGridView.ClearSelection();
                processGridView.CurrentCell = null;
            }
        }

 
        private async void StartSortingButton_Click(object sender, EventArgs e)
        {
            DisableSelectSourseControls(true);
            DateTime startDate = DateTime.Now;
            string incommingArrayStr = JsonConvert.SerializeObject(array); 
            string methodName = $"sort - {sorter.SorterName}, order - {order.OrderName}";
            sorter.ComparingElementsEvent += Sorter_ComparingElementsEvent;
            sorter.ChangingElementsEvent += Sorter_ChangingElementsEvent;
            order.ArraySize = (array.GetLength(0), array.GetLength(1));
            sorter.SortList = order.GetNumerator();
            sorter.Array = array;
            sortingProcessLabel.Text = "Sorting culculation. Wait some time....";
            //string message = $"Start sortimg with method - {methodName}";
            //logger.Log(message);
            sorter.Sort();
            sortingProcessLabel.Text = "Sorting end. Look the process";
            DateTime endDate = DateTime.Now;
            string sortedArrayStr = JsonConvert.SerializeObject(array);
            using (SortedArrayContext db = new SortedArrayContext())
            {
                SortedArray sortedArray = new SortedArray { Id = GuidGenerator.Generate(), SorterName = methodName, IncommingArray = incommingArrayStr, SortingArray = sortedArrayStr, SortingStart = startDate.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fff"), SortingEnd = endDate.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fff") };
                db.SortedArrays.Add(sortedArray);
                db.SaveChanges();
            }
            invoker.Run();
        }

        private void Sorter_ComparingElementsEvent(object sender, ArraySorterEventArgument argument)
        {
            Command compareCommand = new CompareCommand(processGridView, argument.FirstElement, argument.SecondElement);           
            invoker.SetCommand(compareCommand);
        }

        private void Sorter_ChangingElementsEvent(object sender, ArraySorterEventArgument argument)
        {
            Command changeCommand = new ChangeCommand(processGridView, argument.FirstElement, argument.SecondElement);
            invoker.SetCommand(changeCommand);
        }

        private void DisableSelectSourseControls(bool disableControl)
        {
            fileRadioButton.Enabled = !disableControl;
            ramdomRadioButton.Enabled = !disableControl;
            arraySourcePanel.Enabled = !disableControl;
            sortMethodComboBox.Enabled = !disableControl;
            confirmMethodButton.Enabled = !disableControl;
            arraySourcePanel.Visible = !disableControl;

        }

        private void ConfirmMethodButton_Click(object sender, EventArgs e)
        {
           if (sortMethodComboBox.SelectedValue != null && orderComboBox.SelectedValue != null)
            {
                sorter = (ISorter)sortMethodComboBox.SelectedValue;
                order = (IOrder)orderComboBox.SelectedValue;
                EnableSortingProcess(true);
            }
            else
            {
                EnableSortingProcess(false);
            }

        }


        private void EnableSortingProcess(bool enableSorting)
        {
            speedDownButton.Enabled = enableSorting;
            speedUpButton.Enabled = enableSorting;
            startSortingButton.Enabled = enableSorting;
        }


        private void SpeedUpButton_Click(object sender, EventArgs e)
        {
            ChangeSpeed(true);
        }

        private void SpeedDownButton_Click(object sender, EventArgs e)
        {
            ChangeSpeed(false);
        }

        private void ChangeSpeed(bool speedy)
        {
            if (speedy)
                invoker.Speed -= 10;
            else
                invoker.Speed += 10;
        }
    }
}
