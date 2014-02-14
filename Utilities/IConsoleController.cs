/*
 *   Writers Work Bench Copyright (C) 2014  William W. Westlake Jr.
 *   wwestlake@lagdaemon.com
 *   
 *   source code: https://github.com/wwestlake/ExperimentalOS.git 
 * 
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *    (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 * 
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
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
