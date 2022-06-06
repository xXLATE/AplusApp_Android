using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App5XamarinMob.Models;
using App5XamarinMob.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5XamarinMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProjectPage : ContentPage
    {
        public EditProjectViewModel ViewModel { get; private set; }

        public EditProjectPage(EditProjectViewModel proj)
        {
            InitializeComponent();
            ViewModel = proj;
            this.BindingContext = proj;
        }
    }
}