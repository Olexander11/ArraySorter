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
            fileButton.Click += FileButton_Click;
            confirmButton.Click += ConfirmButton_Click;
            Logger.Logger logger = Logger.Logger.getInstance();
        }

        public event EventHandler<EventArgs> ArrayComplit;
        private FileSourceTypeEnum fileSourceType = FileSourceTypeEnum.none;
        private int[,] array;
        private string filename;
        private Logger.Logger logger;

        public int[,] GetArray()
        {
            return array;
        }

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            IFileArrayCreator fileArrayCreator = null;
            try
            {
                switch (fileSourceType)
                {
                    case FileSourceTypeEnum.xml:
                        try
                        {
                            fileArrayCreator = new XMLCreator(filename);                            
                        }
                        catch (Exception)
                        {
                            try
                            {
                                fileArrayCreator = new JSONCreator(filename);                               
                            }
                            catch (Exception ex)
                            {
                                logger.Log(ex.Message);
                                throw;
                            }
                        }

                        break;
                    case FileSourceTypeEnum.json:
                    case FileSourceTypeEnum.none:
                        try
                        {

                            fileArrayCreator = new JSONCreator(filename);                            
                        }
                        catch (Exception)
                        {
                            try
                            {
                                fileArrayCreator = new XMLCreator(filename);                                
                            }
                            catch (Exception ex)
                            {
                                logger.Log(ex.Message);
                                throw;
                            }
                        }
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("File parsing failed, try again!");
                logger.Log("File parsing failed, try again!");
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
                    logger.Log("Array creating failed, try again!");
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
            }
            if (filename.ToLower().EndsWith(".xml"))
            {
                fileSourceType = FileSourceTypeEnum.xml;
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
