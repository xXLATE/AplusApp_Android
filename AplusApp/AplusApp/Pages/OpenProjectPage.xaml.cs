﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplusApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpenProjectPage : TabbedPage
    {
        public string ProjectName { get; set; }

        public OpenProjectPage(string projectName)
        {
            InitializeComponent();

            ProjectName = projectName;
            this.BindingContext = this;
        }
    }
}