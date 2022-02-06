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
    public partial class ProjectsPage : ContentPage
    {
        public ProjectsPage()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);
        }

        private async void TappedProject(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new OpenProjectPage(ProjectsList.SelectedItem.ToString()));
        }
    }
}