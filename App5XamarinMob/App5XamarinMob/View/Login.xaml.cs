using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App5XamarinMob.Models;
using App5XamarinMob.ViewModel;
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
            BindingContext = new LoginViewModel { Navigation = this.Navigation};
        }
    }
}