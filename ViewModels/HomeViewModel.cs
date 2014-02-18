using LagDaemon.WWB.Model;
using LagDaemon.WWB.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LagDaemon.WWB.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        internal MainWindowViewModel mainWindowVM;
        protected List<Project> projects = new List<Project>();
        protected Project selectedProject = null;
        protected ProjectViewModel currentProjectVM;

        public HomeViewModel(MainWindowViewModel mainWindowVM) : base()
        {
            this.mainWindowVM = mainWindowVM;
        }

        protected override void Initialize()
        {
            foreach (Project project in TestProjects) projects.Add(project);
        }

        public bool ProjectListEnabled { get { return !IsInEditMode; } }

        public string Home { get { return "Home"; } }

        public Project SelectedProject
        {
            get { return selectedProject; }
            set
            {
                if (value != null) SystemResources.Console.WriteLine("Selected Project: {0}", value.Name);
                SetProperty<Project>(ref selectedProject, value, "SelectedProject");
                currentProjectVM = new ProjectViewModel(this, selectedProject);
                OnPropertyChanged("SelectedProjectViewModel");
                OnPropertyChanged("ProjectVisible");
                currentProjectVM.OnPropertyChanged("ProjectVisible");
            }
        }

        public bool IsInEditMode { get { if (currentProjectVM != null) return currentProjectVM.EditMode; return false; } }

        public ProjectViewModel SelectedProjectViewModel
        {
            get
            {
                return currentProjectVM;
            }
        }


        public IEnumerable<Project> Projects
        {
            get
            {
                return projects;
            }
        }

        public IEnumerable<Project> TestProjects
        {
            get
            {
                for (int i = 0; i < 200; i++) yield return new Project 
                    {
                        Name = string.Format("project{0}",i),
                        Title=string.Format("My very special project #{0}", i), 
                        Author = "William W. Westlake",
                        Copyright = "(C)2014 All Rights Reserved.",
                        Synopsis = "This is a synopsis",
                        Text = "This is some text",
                        Description = "This is the description"
                    };
             }
        }


    }
}
