using ArraySorter.ArrayCreator;
using ArraySorter.ArrayCreator.FileCreator;
using System;
using System.Windows.Forms;

namespace ArraySorter.Controls
{
    public partial class FileSourseControl : UserControl, ISourceControl
    {
        public FileSourseControl()
        {
            InitializeComponent();
            confirmButton.Visible = false;
        }

        public event EventHandler<EventArgs> ArrayComplit;
        private FileSourceTypeEnum fileSourceType = FileSourceTypeEnum.none;
        private int[,] array;
        private string filename;

        public int[,] GetArray()
        {
            return array;
        }

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            if (fileSourceType != FileSourceTypeEnum.none)
            {
                IFileArrayCreator fileArrayCreator = null;
                try
                {
                    switch (fileSourceType)
                    {
                        case FileSourceTypeEnum.xml:
                            fileArrayCreator = new XMLCreator(filename);
                            break;
                        case FileSourceTypeEnum.json:
                            fileArrayCreator = new JSONCreator(filename);
                            break;
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("File parsing failed, try again!");
                    confirmButton.Visible = false;
                }

                if (fileArrayCreator != null)
                {
                    try
                    {
                        array = fileArrayCreator.Create();
                        ArrayComplit?.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Array creating failed, try again!");
                        confirmButton.Visible = false;
                    }
                }
            }
        }

        private void FileButton_Click(object sender, System.EventArgs e)
        {            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                filename = openFileDialog.FileName;
            }

            if (filename.ToLower().EndsWith(".json"))
            {
               fileSourceType = FileSourceTypeEnum.json;
                confirmButton.Visible = true;
            }
            if (filename.ToLower().EndsWith(".xml"))
            {
               fileSourceType = FileSourceTypeEnum.xml;
                confirmButton.Visible = true;
            }
        }
    }

    enum FileSourceTypeEnum
    {
        xml,
        json,
        none
    }
}
