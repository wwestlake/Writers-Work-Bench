using LagDaemon.WWB.Model;
using LagDaemon.WWB.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LagDaemon.WWB.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        Project currentProject = null;
        HomeViewModel home;

        protected override void Initialize()
        {
            home = new HomeViewModel(this);
        }


        public HomeViewModel HomeContext { get { return home;  } }

        


        public bool CanNewProject()
        {
            return true;
        }

        public void NewProject()
        {

        }

        public bool CanOpenProject()
        {
            return true;
        }

        public void OpenProject()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Project";
            dialog.Filter = "WWB Project Files (*.prj)|*.prj";
            if (dialog.ShowDialog().Value)
            {
                MessageBox.Show("Found File " + dialog.FileName);
            }
            else
            {
                MessageBox.Show("Open Project Canceled");
            }
        }


        public bool CanCloseProject()
        {
            return ObjectValidation.IsNotNull(currentProject);
        }

        public void CloseProject()
        {

        }

        public bool CanSaveProject()
        {
            return false;
        }

        public void SaveProject()
        {

        }

        public bool CanSaveProjectAs()
        {
            return ObjectValidation.IsNotNull(currentProject);
        }

        public void SaveProjectAs()
        {

        }

        public bool CanExit()
        {
            return true;
        }

        public void Exit()
        {
            SystemResources.MainWindow.Close();
        }

        public bool CanCloseApplication()
        {
            return false;
        }

    }
}
