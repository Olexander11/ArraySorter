using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraySorter.Logger
{
    public class Logger
    {
        private static string filePath = Path.GetDirectoryName(Application.ExecutablePath);
        private static string fullPathName = Path.Combine(filePath, "log.txt");
        private static Logger instance;

        private Logger()
        { }

        public static Logger getInstance()
        {
            if (instance == null)
                instance = new Logger();
            return instance;
        }

        public void Log(string text)
        {
            string logText = $"{DateTime.Now.ToLongDateString()} | {text}" + Environment.NewLine;
            File.WriteAllText(fullPathName, logText);
        }
    }
}
