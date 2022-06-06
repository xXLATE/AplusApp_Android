using App5XamarinMob.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App5XamarinMob.ViewModel
{
    public class ListProjectViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProjectViewModel> Projects { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
         
        public ICommand CreateStudentCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        ProjectViewModel selectedStudent;

        public INavigation Navigation { get; set; }

        public ListProjectViewModel()
        {
            Projects = new ObservableCollection<ProjectViewModel>();
            foreach(var item in App.db.GetProjects())
            {
                Projects.Add(new ProjectViewModel { Project = item });
            }
            CreateStudentCommand = new Command(CreateStudent);
            BackCommand = new Command(Back);
        }

        public ProjectViewModel SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                if (selectedStudent != value)
                {
                    ProjectViewModel tempStudent = value;
                    tempStudent.Navigation = this.Navigation;
                    selectedStudent = null;
                    OnPropertyChanged("SelectedStudent");
                    Navigation.PushAsync(new ProjectPage(tempStudent));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateStudent()
        {
            Navigation.PushAsync(new AddProjectPage(new AddProjectViewModel() { Navigation = this.Navigation }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
    }
}
