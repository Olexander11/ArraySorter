using ArraySorter.Controls;
using ArraySorter.DB;
using ArraySorter.DllLoader;
using ArraySorter.Models;
using ArraySorter.Models.ArrayModel;
using CommonInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        }
        private int[,] array = null;
        private ISorter sorter = null;
        private IOrder order = null;
        private int speed = 1;
        private bool sortHistoryByAsc = true;

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
                source.DataSource = db.SortedArrays.OrderBy(a => a.SortingStart).ToList();
                if (sortHistoryByAsc)
                    source.DataSource = db.SortedArrays.OrderBy(a => a.SortingStart);
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
        }

        private void FileRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (fileRadioButton.Checked)
            {
                ramdomRadioButton.Checked = false;
                ArraySourceSelected(false);
            }
        }

        private void ArraySourceSelected(bool isRandom)
        {
            arraySourcePanel.SuspendLayout();
            Control control = null;
            if (isRandom)
            {
                control = new RandomArrayControl();

            }
            else
            {
                control = new FileSourseControl();

            }
            arraySourcePanel.Controls.Add(control);
            arraySourcePanel.ResumeLayout();
            (control as ISourceControl).ArrayComplit += ArrayDesk_ArrayComplit;
        }

        private void ArrayDesk_ArrayComplit(object sender, EventArgs e)
        {
            if (sender is ISourceControl source)
            {
                array = source.GetArray();
                processGridView.DataSource = array;
            }
        }

 
        private void StartSortingButton_Click(object sender, EventArgs e)
        {
            DisableSelectSourseControls(true);
            DateTime startDate = DateTime.Now;
            string incommingArrayStr = ArrayModelHelper.ArrayToString(array);
            string methodName = $"sort - {sorter.SorterName}, order - {order.OrderName}";
            sorter.ComparingElementsEvent += Sorter_ComparingElementsEvent;
            sorter.ChangingElementsEvent += Sorter_ChangingElementsEvent;
            sorter.Sort();
            DateTime endDate = DateTime.Now;
            string sortedArrayStr = ArrayModelHelper.ArrayToString(array);
            using (SortedArrayContext db = new SortedArrayContext())
            {
                SortedArray sortedArray = new SortedArray { Id = GuidGenerator.Generate(), SorterName = methodName, IncommingArray = incommingArrayStr, SortingArray = sortedArrayStr, SortingStart = startDate, SortingEnd = endDate };
                db.SortedArrays.Add(sortedArray);
                db.SaveChanges();
            }
        }

        private void Sorter_ComparingElementsEvent(object sender, EventArgs e)
        {
            ArraySorterEventArgument argument = (ArraySorterEventArgument)sender;
            processGridView.Rows[argument.firstElement.Item1].Cells[argument.firstElement.Item2].Style.BackColor = Color.Green;
            processGridView.Rows[argument.secondElement.Item1].Cells[argument.secondElement.Item2].Style.BackColor = Color.Green;
            Thread.Sleep(speed);
            processGridView.Rows[argument.firstElement.Item1].Cells[argument.firstElement.Item2].Style.BackColor = Color.White;
            processGridView.Rows[argument.secondElement.Item1].Cells[argument.secondElement.Item2].Style.BackColor = Color.White;
        }

        private void Sorter_ChangingElementsEvent(object sender, EventArgs e)
        {
            ArraySorterEventArgument argument = (ArraySorterEventArgument)sender;
            processGridView.Rows[argument.firstElement.Item1].Cells[argument.firstElement.Item2].Style.BackColor = Color.Red;
            processGridView.Rows[argument.secondElement.Item1].Cells[argument.secondElement.Item2].Style.BackColor = Color.Red;
            object temtNum = processGridView.Rows[argument.firstElement.Item1].Cells[argument.firstElement.Item2].Value;
            processGridView.Rows[argument.firstElement.Item1].Cells[argument.firstElement.Item2].Value = processGridView.Rows[argument.secondElement.Item1].Cells[argument.secondElement.Item2].Value;
            processGridView.Rows[argument.secondElement.Item1].Cells[argument.secondElement.Item2].Value = temtNum;
            Thread.Sleep(speed);
            processGridView.Rows[argument.firstElement.Item1].Cells[argument.firstElement.Item2].Style.BackColor = Color.White;
            processGridView.Rows[argument.secondElement.Item1].Cells[argument.secondElement.Item2].Style.BackColor = Color.White;
        }

        private void DisableSelectSourseControls(bool disableControl)
        {
            fileRadioButton.Enabled = disableControl;
            ramdomRadioButton.Enabled = disableControl;
            arraySourcePanel.Enabled = disableControl;
            sortMethodComboBox.Enabled = disableControl;
            confirmMethodButton.Enabled = disableControl;
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
    }
}
