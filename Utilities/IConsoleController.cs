using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.Utilities
{
    public interface IConsoleController
    {
        bool IsVisible { get; }
        void ShowConsole();
        void HideConsole();
        void WriteLine(string fmt, params object[] args);
        void WriteLine();
        void WriteLine(string msg);
        void LogEntry(string fmt, params object[] args);
        void LogEntry(string msg);
        void LogException(Exception ex);
        void Write(string msg);
        void Write(string fmt, params object[] args);
        void Write();
    }
}
