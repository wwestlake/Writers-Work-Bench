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
using LagDaemon.WWB.WWBMain;
using LagDaemon.WWB.Utilities;
using LagDaemon.WWB.ViewModels;
using LagDaemon.WWB.WWBMain;

namespace Startup
{
    class Program : Application
    {
        static Program app;
        static MainWindowViewModel vm;
        static MessageWindowViewModel messageVM;
        static MessageWindow messageWindow;

        [STAThread]
        static void Main(string[] args)
        {
            ProductStamp();
            app = new Program();
            vm = new MainWindowViewModel();
            MainWindow window = new MainWindow();
            SystemResources.MainWindow = window;
            window.DataContext = vm;
            window.Closing += window_Closing;
            app.Run(window);
        }

        static void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!vm.CanCloseApplication())
            {
                e.Cancel = true;
                ShowMessage("Not all data base been saved.  Do you want to save?");
                //MessageBoxResult result = MessageBox.Show("Not all data has been saved.\nDo you want to save?", "Application Closing", MessageBoxButton.YesNoCancel);
                MessageWindowResults result = messageVM.Result;
                if (result == MessageWindowResults.Yes)
                {
                    vm.SaveProject();
                    e.Cancel = false;
                }
                else if (result == MessageWindowResults.No)
                {
                    e.Cancel = false;
                }
                
                if (!e.Cancel) SystemResources.Console.LogEntry("Application Shutdown!");
            }
        }


        static void ShowMessage(string message)
        {
            messageWindow = new MessageWindow();
            messageVM = new MessageWindowViewModel(messageWindow, message);
            messageVM.OkVisibility = Visibility.Collapsed;
            messageWindow.DataContext = messageVM;
            messageWindow.ShowDialog();
        }

        static void ProductStamp()
        {
#if DEBUG

            string product = SystemResources.Info.ProductName;
            string company = SystemResources.Info.CompanyName;
            string version = SystemResources.Info.Version.ToString();
            string copyright = SystemResources.Info.CopyrightHolder;

            SystemResources.Console.WriteLine("{0} Version {1}", product, version);
            SystemResources.Console.WriteLine("{0}", copyright);
            SystemResources.Console.WriteLine("All Rights Reserved");
            SystemResources.Console.WriteLine();
            SystemResources.Console.WriteLine("Debug console active.  This console may be turned off in user preferences.");
            SystemResources.Console.WriteLine("--------------------------------------------------------------------------");
            SystemResources.Console.WriteLine();
            SystemResources.Console.LogEntry("Application Startup");

#else
            SystemResources.Console.HideConsole();

#endif
        }

    }
}
