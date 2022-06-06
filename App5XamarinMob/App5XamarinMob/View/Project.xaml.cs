using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App5XamarinMob.Models;
using App5XamarinMob.ViewModel;

namespace App5XamarinMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectPage : TabbedPage
    {

        public ProjectPage(ProjectViewModel project)
        {
            InitializeComponent();
            BindingContext = project;
        }

    }
}