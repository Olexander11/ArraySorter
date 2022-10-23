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
        }

        public event EventHandler<EventArgs> ArrayComplit;
        private FileSourceTypeEnum fileSourceType = FileSourceTypeEnum.none;

        public int[,] GetArray()
        {
            throw new NotImplementedException();
        }

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            if (fileSourceType != FileSourceTypeEnum.none)
            {
                IFileArrayCreator fileArrayCreator = null;
                switch (fileSourceType)
                {
                    case FileSourceTypeEnum.xml:
                        fileArrayCreator = new XMLCreator("path");
                        break;
                    case FileSourceTypeEnum.json:
                        fileArrayCreator = new JSONCreator("path");     
                        break;
                }
                if (fileArrayCreator != null)
                {
                    fileArrayCreator.Create();
                }

            }
        }

        private void FileSourseControl_ArrayComplit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    enum FileSourceTypeEnum
    {
        xml,
        json,
        none
    }
}
