﻿using RideShare.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RideShare.View
{
    public partial class ProfileMenuPage : ContentPage
    {
        public ProfileMenuPage() 
        {
            InitializeComponent();
            BindingContext = new ProfileMenuViewModel(Navigation);
        }
    }
}
