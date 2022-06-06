using App5XamarinMob.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace App5XamarinMob.ViewModel
{
    public class EditProjectViewModel : INotifyPropertyChanged
    {
        public Project Projects { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand SaveCommand { protected set; get; }
        public ICommand TakePhotoCommand { protected set; get; }
        public ICommand DoPhotoCommand { protected set; get; }
        public ICommand CanselCommand { protected set; get; }
        public ICommand DeleteCommand { protected set; get; }
        public INavigation Navigation { get; set; }

        public EditProjectViewModel()
        {
            Projects = new Project();
            SaveCommand = new Command(AddBtn);
            TakePhotoCommand = new Command(AddImageBtn);
            DoPhotoCommand = new Command(TakePhotoAsync);
            CanselCommand = new Command(CancelBtn);
            DeleteCommand = new Command(Delete);
        }

        public string Name
        {
            get { return Projects.Name; }
            set
            {
                Projects.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Addres
        {
            get { return Projects.Address; }
            set
            {
                Projects.Address = value;
                OnPropertyChanged("Addres");
            }
        }

        public string Email
        {
            get { return Projects.Email; }
            set
            {
                Projects.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Description
        {
            get { return Projects.Description; }
            set
            {
                Projects.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public string TelephoneNumber
        {
            get { return Projects.TelephoneNumber1; }
            set
            {
                Projects.TelephoneNumber1 = value;
                OnPropertyChanged("TelephoneNumber");
            }
        }

        public string ImgPath
        {
            get { return Projects.ImagePath; }
            set
            {
                Projects.ImagePath = value;
                OnPropertyChanged("ImgPath");
            }
        }

        public async void CancelBtn()
        {
            await Navigation.PopAsync();
        }

        public async void Delete()
        {
            try
            {
                App.db.DelProj(Projects.Id);
            }
            catch
            {

            }
            await Navigation.PopAsync();
        }

        public async void AddBtn()
        {
            //List.Projects.Add(new Project(ProjectNameTxt.Text, ProjectDescriptionTxt.Text, TelNumber1Txt.Text, EmailTxt.Text, AddressTxt.Text));

            try
            {
               
                App.db.SaveItem(Projects);
                await Navigation.PopAsync();
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Error", "Загрузка в базу данных неуспешно", "Ok");
            }

        }
        public async void TakePhotoAsync()
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
                ImgPath = photo.FullPath;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        public async void AddImageBtn()
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
                ImgPath = photo.FullPath;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
    }
}