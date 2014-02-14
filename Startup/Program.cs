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
using System.Windows;
using LagDaemon.WWB.WWBMain;
using LagDaemon.WWB.Utilities;

namespace Startup
{
    class Program : Application
    {
        static Program app;

        [STAThread]
        static void Main(string[] args)
        {
#if DEBUG
            ProductStamp();
#else
            Debug.Console.HideConsole();
#endif
            app = new Program();
            MainWindow window = new MainWindow();
            window.Closing += window_Closing;
            app.Run(window);
        }

        static void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = MessageBox.Show("Are you sure you want to close?", "Application Closing", MessageBoxButton.YesNo) == MessageBoxResult.No;
            if (! e.Cancel) Debug.Console.LogEntry("Application Shutdown!");
        }


        static void ProductStamp()
        {
            string product = ApplicationInfo.ProductName;
            string company = ApplicationInfo.CompanyName;
            string version = ApplicationInfo.Version.ToString();
            string copyright = ApplicationInfo.CopyrightHolder;

            Debug.Console.WriteLine("{0} Version {1}", product, version);
            Debug.Console.WriteLine("{0}", copyright);
            Debug.Console.WriteLine("All Rights Reserved");
            Debug.Console.WriteLine();
            Debug.Console.WriteLine("Debug console active.  This console may be turned off in user preferences.");
            Debug.Console.WriteLine("--------------------------------------------------------------------------");
            Debug.Console.WriteLine();
            Debug.Console.LogEntry("Application Startup");
        }

    }
}
