using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App5XamarinMob.Models;
using App5XamarinMob.ViewModel;

namespace App5XamarinMob
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ListProjectViewModel { Navigation = this.Navigation};
        }
    }
}