using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LagDaemon.WWB.ViewModels
{
    public static class MessageWindowCommands
    {
        private static readonly RoutedCommand okCommand = new RoutedCommand("Ok", typeof(MessageWindowCommands));
        private static readonly RoutedCommand yesCommand = new RoutedCommand("Yes", typeof(MessageWindowCommands));
        private static readonly RoutedCommand noCommand = new RoutedCommand("No", typeof(MessageWindowCommands));
        private static readonly RoutedCommand cancelCommand = new RoutedCommand("Cancel", typeof(MessageWindowCommands));

        public static RoutedCommand Ok { get { return okCommand; } }
        public static RoutedCommand Yes { get { return yesCommand; } }
        public static RoutedCommand No { get { return noCommand; } }
        public static RoutedCommand Cancel { get { return cancelCommand; } }

    }
}
