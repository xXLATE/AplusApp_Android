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
    public partial class EditProjectPage : ContentPage
    {
        readonly Project project;

        public EditProjectPage(Project proj)
        {
            project = proj;
            InitializeComponent();
            FillFields();
        }

        public void FillFields()
        {
            ProjectNameTxt.Text = project.Name;
            ProjectDescriptionTxt.Text = project.Description;
            TelNumber1Txt.Text = project.TelephoneNumber1;
            EmailTxt.Text = project.Email;
            AddressTxt.Text = project.Address;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Изменение", $"Вы точно хотите удалить {project.Name}?", "УДАЛИТЬ", "ОТМЕНА");

            if (result)
            {
                try
                {
                    App.db.DelProj(project.Id);
                }
                catch
                {
                    await DisplayAlert("Error", "Загрузка в базу данных неуспешно", "Ok");
                }
                await Navigation.PopAsync();
            }
        }

        private async void CancelBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void EditBtn_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Изменение", $"Вы точно хотите изменить {project.Name}?", "ИЗМЕНИТЬ", "ОТМЕНА");

            if (result)
            {
                project.Name = ProjectNameTxt.Text;
                project.Description = ProjectDescriptionTxt.Text;
                project.TelephoneNumber1 = TelNumber1Txt.Text;
                project.Address = AddressTxt.Text;
                project.Email = EmailTxt.Text;

                try
                {
                    App.db.SaveItem(project);
                }
                catch
                {
                    await DisplayAlert("Error", "Загрузка в базу данных неуспешно", "Ok");
                }

                await Navigation.PopAsync();
            }
        }
    }
}