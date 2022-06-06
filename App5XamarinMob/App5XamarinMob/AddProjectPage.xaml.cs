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

namespace App5XamarinMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProjectPage : ContentPage
    {
        private string path;
        public AddProjectPage()
        {
            InitializeComponent();
        }

        private async void CancelBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void AddBtn_Clicked(object sender, EventArgs e)
        {
            //List.Projects.Add(new Project(ProjectNameTxt.Text, ProjectDescriptionTxt.Text, TelNumber1Txt.Text, EmailTxt.Text, AddressTxt.Text));

            try
            {
                App.db.SaveItem(new Project(ProjectNameTxt.Text, ProjectDescriptionTxt.Text, TelNumber1Txt.Text, EmailTxt.Text, AddressTxt.Text, path));
                await Navigation.PopAsync();
            }
            catch
            {
                await DisplayAlert("Error", "Загрузка в базу данных неуспешно", "Ok");
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