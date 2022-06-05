using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App5XamarinMob.Models;

namespace App5XamarinMob
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            UpdateList();
        }

        private async void ProjectsLstview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ProjectPage((Project)e.Item));
        }

        protected override void OnAppearing()
        {
            UpdateList();
            base.OnAppearing();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //await DisplayAlert("Alert", "Tapped", "OK");
            //List.Projects.Add(new Project($"Проект{List.Projects.Count + 1}", $"Description{List.Projects.Count + 1}", "89047182492", "89047182402", "qwerty@mail.com", "Kazan"));
            //UpdateList();

            await Navigation.PushAsync(new AddProjectPage()); await Navigation.PushAsync(new AddProjectPage());

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            //List.Projects.Add(new Project($"Проект{List.Projects.Count + 1}", $"Description{List.Projects.Count + 1}", "89047182492", "89047182402", "qwerty@mail.com", "Kazan"));
            await Navigation.PushAsync(new AddProjectPage());
        }

        public void UpdateList()
        {
            ProjectsLstview.ItemsSource = null;
            ProjectsLstview.ItemsSource = App.Db.GetProjects();
        }
    }
}