using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplusApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void RegistrationBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjectsPage());
        }
    }
}