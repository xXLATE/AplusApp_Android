using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App5XamarinMob.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5XamarinMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void RigistrationPageBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {

            var lst = App.Db.GetClients();
            bool state = false;

            foreach (var item in lst)
            {
                if (item.Login == LoginEntry.Text)
                {
                    if (item.Password == PasswordEntry.Text)
                    {
                        state = true;
                        await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
                    }
                }
            }

            if (!state)
                await DisplayAlert("Уведомление", "Не правилный логин или пароль", "Ok");
        }
    }
}