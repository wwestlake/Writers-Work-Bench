using LagDaemon.WWB.AbstractPatterns;
/*
 *   Writers Work Bench Copyright (C) 2014  William W. Westlake Jr.
 *   wwestlake@lagdaemon.com
 *   
 *   source code: https://github.com/wwestlake/Writers-Work-Bench.git
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
using System.Windows;

namespace LagDaemon.WWB.Utilities
{
    public static class SystemResources 
    {
        private static Singleton<ConsoleController> controller = new Singleton<ConsoleController>();
        private static Singleton<ApplicationInfo> appinfo = new Singleton<ApplicationInfo>();
        private static Window mainWindow;

        public static IConsoleController Console
        {
            get
            {
                return controller.Instance;
            }
        }

        public static IApplicationInfo Info
        {
            get 
            {
                return appinfo.Instance;
            }
        }

        public static Window MainWindow
        {
            get
            {
                return mainWindow;
            }
            set
            {
                if (ObjectValidation.IsNull(mainWindow)) mainWindow = value;
                else throw new ApplicationException("Can not change MainWindow once set.");
            }
        }

    }
}
