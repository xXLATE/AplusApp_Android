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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void RegBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (PassRegEntry.Text == PassConfirmRegEntry.Text)
                    App.Db.SaveClient(new Client(EmailRegEntry.Text, LoginRegEntry.Text, PassRegEntry.Text));
                await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            }
            catch
            {
                await DisplayAlert("Уведомление", "Не удалось зарегистрироваться", "Ok");
            }
        }
    }
}