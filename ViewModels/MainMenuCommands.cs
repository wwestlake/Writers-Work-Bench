using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LagDaemon.WWB.ViewModels
{
    public static class MainMenuCommands
    {
        private static readonly RoutedCommand newProject = new RoutedCommand("NewProject", typeof(MainMenuCommands));
        private static readonly RoutedCommand openProject = new RoutedCommand("OpenProject", typeof(MainMenuCommands));
        private static readonly RoutedCommand closeProject = new RoutedCommand("CloseProject", typeof(MainMenuCommands));
        private static readonly RoutedCommand saveProject = new RoutedCommand("SaveProject", typeof(MainMenuCommands));
        private static readonly RoutedCommand saveProjectAs = new RoutedCommand("SaveProjectAs", typeof(MainMenuCommands));
        private static readonly RoutedCommand exit = new RoutedCommand("Exit", typeof(MainMenuCommands));

        public static RoutedCommand NewProject { get { return newProject; } }
        public static RoutedCommand OpenProject { get { return openProject; } }
        public static RoutedCommand CloseProject { get { return closeProject; } }
        public static RoutedCommand SaveProject { get { return saveProject; } }
        public static RoutedCommand SaveProjectAs { get { return saveProjectAs; } }
        public static RoutedCommand Exit { get { return exit; } }

    }
}
