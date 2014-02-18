using LagDaemon.WWB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LagDaemon.WWB.ViewModels
{
    public class ProjectViewModel : ViewModelBase
    {
        protected Project project;
        protected bool editMode = false;
        protected HomeViewModel home;

        public ProjectViewModel(HomeViewModel home, Project project)
        {
            this.project = project;
            this.home = home;
            OnPropertyChanged("ProjectVisible");
        }
        
        protected override void Initialize()
        {
        }

        public Visibility ProjectVisible
        {
            get
            {
                return (project != null ? Visibility.Visible : Visibility.Collapsed);
            }
        }

        public Project Project
        {
            get
            {
                return project;
            }
        }

        public bool EditMode
        {
            get
            {
                return editMode;
            }
            set
            {
                SetProperty<bool>(ref editMode, value, "EditMode");
                OnPropertyChanged("SelectedProjectViewModel");
                home.OnPropertyChanged("IsInEditMode");
                home.OnPropertyChanged("ProjectListEnabled");
            }
        }

        public bool CanEditProject()
        {
            return true;
        }

        public void EditProject()
        {
            EditMode = true;
        }

        public bool CanSaveProject()
        {
            return true;
        }

        public void SaveProject()
        {
            EditMode = false;
        }

        public bool CanCancelEditProject()
        {
            return true;
        }

        public void CancelEditProject()
        {
            EditMode = false;
        }


        public Visibility Debug
        {
            get
            {
#if DEBUG
                return Visibility.Visible;
#else
                return Visibility.Collapsed;
#endif
            }
        }

    }
}
