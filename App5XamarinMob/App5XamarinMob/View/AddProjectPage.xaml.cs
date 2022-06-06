//yjdfz new
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App5XamarinMob.Models;
using App5XamarinMob.db;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.IO;
using App5XamarinMob.ViewModel;

namespace App5XamarinMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProjectPage : ContentPage
    {
        private string path;
        public AddProjectPage(AddProjectViewModel projectViewModel)
        {
            InitializeComponent();
            BindingContext = projectViewModel;
        }
    }
}