using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App5XamarinMob.Models;

namespace App5XamarinMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectPage : TabbedPage
    {
        readonly Project project;
        public static string Name;

        protected override void OnAppearing()
        {
            FillInfo();
            base.OnAppearing();
        }

        public ProjectPage(Project project)
        {
            this.project = project;
            Name = project.Name;
            InitializeComponent();
            FillInfo();
        }

        public void FillInfo()
        {
            ProjectDescriptionLbl.Text = project.Description;
            AddressLbl.Text = project.Address;
            EmailLbl.Text = project.Email;
            TelephoneNumberLbl1.Text = project.TelephoneNumber1;
            Img1.Source = project.ImagePath;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProjectPage(project));
        }
    }
}