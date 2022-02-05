﻿using System;
using Xamarin.Forms;
using AplusApp.Pages;
using Xamarin.Forms.Xaml;

namespace AplusApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AuthPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
