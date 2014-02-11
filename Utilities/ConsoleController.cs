using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Utilities
{
    internal class ConsoleController : IConsoleController
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        private string logFileName;
        private string currentLogFile;
        private FileStream logStream;
        private TextWriter writer;
        
        internal ConsoleController() 
        {
            logFileName = DateTime.Now.ToLongDateString().Replace("\\", "-") + ".log";
            IsVisible = true;
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
            if (!Directory.Exists(ApplicationInfo.ApplicationLogDirectory))
            {
                Directory.CreateDirectory(ApplicationInfo.ApplicationLogDirectory);
            }
            currentLogFile = ApplicationInfo.ApplicationLogDirectory + Path.DirectorySeparatorChar + logFileName;
            logStream = new FileStream(currentLogFile, FileMode.Append | FileMode.OpenOrCreate, FileAccess.Write);
            writer = new StreamWriter(logStream);
            WriteLine(currentLogFile);
        }


        public bool IsVisible { get; internal set; }

        public void ShowConsole()
        {
            if (!IsVisible)
            {
                ShowWindow(GetConsoleWindow(), SW_SHOW);
                IsVisible = true;
            }
        }

        public void HideConsole()
        {
            if (IsVisible)
            {
                ShowWindow(GetConsoleWindow(), SW_HIDE);
                IsVisible = false;
            }
        }

        public void WriteLine(string fmt, params object[] args)
        {
            if (IsVisible) Console.WriteLine(fmt, args);
        }

        public void WriteLine()
        {
            WriteLine("");
        }

        public void WriteLine(string msg)
        {
            WriteLine("{0}", msg);
        }

        public void LogEntry(string fmt, params object[] args)
        {
            DateTime timeStamp = DateTime.Now;
            StringBuilder message = new StringBuilder();
            message.AppendFormat("{0} -- ", timeStamp);
            message.AppendFormat(fmt, args);
            WriteLine(message.ToString());
            writer.WriteLine(message.ToString());
            writer.Flush();
        }

        public void LogException(Exception ex)
        {
            LogEntry("Exception - {0}, {1}", ex.GetType().ToString(), ex.Message);
            LogEntry("Stack Trace Follows:");
            LogEntry(ex.StackTrace);
        }


        public void LogEntry(string msg)
        {
            LogEntry("{0}", msg);
        }


        public void Write(string msg)
        {
            Write("0", msg);
        }

        public void Write(string fmt, params object[] args)
        {
            if (IsVisible) Console.Write(fmt, args);
        }

        public void Write()
        {
            Write("");
        }

    }
}
