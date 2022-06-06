using App5XamarinMob.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace App5XamarinMob.ViewModel
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public RegistrationViewModel()
        {
            RegistrationCommand = new Command(RegBtn);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand RegistrationCommand { protected set; get; }
         
        public INavigation Navigation { get; set; }
        public Client Client { get; private set; } = new Client("", "", "");
        public string Login
        {
            get { return Client.Login; }
            set
            {
                Client.Login = value;
                OnPropertyChanged("Login");
            }
        }
     
        public string Email
        {
            get { return Client.Email; }
            set
            {
                Client.Email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Password
        {
            get { return Client.Password; }
            set
            {
                Client.Password = value;
                OnPropertyChanged("Password");
            }
        }
        private string passConf = "";
        public string PasswordConfirm
        {
            get { return passConf; }
            set
            {
                passConf= value;
                OnPropertyChanged("PasswordConfirm");
            }
        }

        private async void RegBtn()
        {
            try
            {
                if (Client.Password == PasswordConfirm)
                    App.Db.SaveClient(Client);
                await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Уведомление", "Не удалось зарегистрироваться", "Ok");
            }
        }
    }
}
