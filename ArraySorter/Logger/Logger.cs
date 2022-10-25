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
        private static NLog.Logger instance;

        private Logger()
        { }

        public static NLog.Logger getInstance()
        {
            if (instance == null)
            {
                instance = NLog.LogManager.GetCurrentClassLogger();
            }
            return instance;
        }
    }
}
