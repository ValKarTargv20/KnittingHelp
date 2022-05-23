using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KnittingHelp.ViewModel
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ProjectListViewModel plvm;
        public Project Project { get; private set; }
        public ProjectViewModel()
        {
            Project = new Project();
        }

        public ProjectListViewModel ListViewModel
        {
            get { return plvm; }
            set
            {
                if (plvm != value)
                {
                    plvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Name
        {
            get { return Project.Name; }
            set
            {
                if (Project.Name != value)
                {
                    Project.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Yarn
        {
            get { return Project.Yarn; }
            set
            {
                if (Project.Yarn != value)
                {
                    Project.Yarn = value;
                    OnPropertyChanged("Yarn");
                }
            }
        }
        public string Tools
        {
            get { return Project.Tools; }
            set
            {
                if (Project.Tools != value)
                {
                    Project.Tools = value;
                    OnPropertyChanged("Tools");
                }
            }
        }
        public string Addons
        {
            get { return Project.Addons; }
            set
            {
                if (Project.Addons != value)
                {
                    Project.Addons = value;
                    OnPropertyChanged("Addons");
                }
            }
        }
        public string Project_pic
        {
            get { return Project.Project_pic; }
            set
            {
                if (Project.Project_pic != value)
                {
                    Project.Project_pic = value;
                    OnPropertyChanged("Project_pic");
                }
            }
        }
        public string Pattern_pic
        {
            get { return Project.Pattern_pic; }
            set
            {
                if (Project.Pattern_pic != value)
                {
                    Project.Pattern_pic = value;
                    OnPropertyChanged("Pattern_pic");
                }
            }
        }
        public string Notes
        {
            get { return Project.Notes; }
            set
            {
                if (Project.Notes != value)
                {
                    Project.Notes = value;
                    OnPropertyChanged("Notes");
                }
            }
        }
        public string Pattern_url
        {
            get { return Project.Pattern_url; }
            set
            {
                if (Project.Pattern_url != value)
                {
                    Project.Pattern_url = value;
                    OnPropertyChanged("Pattern_url");
                }
            }
        }
        public int TimerProject
        {
            get { return Project.TimerProject; }
            set
            {
                if (Project.TimerProject != value)
                {
                    Project.TimerProject = value;
                    OnPropertyChanged("TimerProject");
                }
            }
        }
        public int Rows
        {
            get { return Project.Rows; }
            set
            {
                if (Project.Rows != value)
                {
                    Project.Rows = value;
                    OnPropertyChanged("Rows");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim())) ||
                    (string.IsNullOrEmpty(Yarn.Trim())) ||
                    (string.IsNullOrEmpty(Tools.Trim()))||
                    (string.IsNullOrEmpty(Addons.Trim())) ||
                    (string.IsNullOrEmpty(Project_pic.Trim())) ||
                    (string.IsNullOrEmpty(Pattern_pic.Trim())) ||
                    (string.IsNullOrEmpty(Notes.Trim())) ||
                    (string.IsNullOrEmpty(Pattern_url.Trim())));
            }
        }

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
