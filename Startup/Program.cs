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
