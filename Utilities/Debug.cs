using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Utilities
{
    public static class Debug
    {
        private static IConsoleController console;

        public static IConsoleController Console
        {
            get
            {
                if (null == console) console = new ConsoleController();
                return console as IConsoleController;
            }
        }
    }
}
