using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LagDaemon.WWB.ViewModels
{
    public static class EditCommands
    {
        private static readonly RoutedCommand editCommand = new RoutedCommand("Edit", typeof(EditCommands));
        private static readonly RoutedCommand saveCommand = new RoutedCommand("Save", typeof(EditCommands));
        private static readonly RoutedCommand cancelCommand = new RoutedCommand("Cancel", typeof(EditCommands));

            public static RoutedCommand Edit { get { return editCommand; } }
            public static RoutedCommand Save { get { return saveCommand; } }
            public static RoutedCommand Cancel { get { return cancelCommand; } }

    }
}
