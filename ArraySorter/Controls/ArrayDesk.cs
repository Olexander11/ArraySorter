using ArraySorter.Controls;
using ArraySorter.DB;
using ArraySorter.DllLoader;
using ArraySorter.Models;
using ArraySorter.Models.ArrayModel;
using ArraySorter.SortPlayer;
using CommonInterfaces;
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
            invoker = new Invoker(500);
        }
        private int[,] array = null;
        private ISorter sorter = null;
        private IOrder order = null;
        private bool sortHistoryByAsc = true;
        private Invoker invoker;

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
            invoker.Run();
        }

        private void Sorter_ComparingElementsEvent(object sender, EventArgs e)
        {
            ArraySorterEventArgument argument = (ArraySorterEventArgument)sender;
            Command compareCommand = new CompareCommand(processGridView, argument.firstElement, argument.secondElement);
            Command returnCommand = new ReturnCommand(processGridView, argument.firstElement, argument.secondElement);
            invoker.SetCommand(compareCommand);
            invoker.SetCommand(returnCommand);
        }

        private void Sorter_ChangingElementsEvent(object sender, EventArgs e)
        {
            ArraySorterEventArgument argument = (ArraySorterEventArgument)sender;
            Command changeCommand = new ChangeCommand(processGridView, argument.firstElement, argument.secondElement);
            Command returnCommand = new ReturnCommand(processGridView, argument.firstElement, argument.secondElement);
            invoker.SetCommand(changeCommand);
            invoker.SetCommand(returnCommand);
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


        private void StartSortingButton_Click1(object sender, EventArgs e)
        {
            sorter.SortList = order.GetNumerator();
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
                invoker.Speed += 10;
            else
                invoker.Speed -= 10;
        }
    }
}
