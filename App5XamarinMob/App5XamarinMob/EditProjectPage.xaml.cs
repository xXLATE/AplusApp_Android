using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App5XamarinMob.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5XamarinMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProjectPage : ContentPage
    {
        readonly Project project;
        private string path;

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
            img.Source = project.ImagePath;
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
                if (path != null)
                    project.ImagePath = path;

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
        async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                // для примера сохраняем файл в локальном хранилище
                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                // загружаем в ImageView
                path = photo.FullPath;
                img.Source = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private async void AddImageBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                // выбираем фото
                var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);

                // загружаем в ImageView
                path = photo.FullPath;
                img.Source = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
    }
}