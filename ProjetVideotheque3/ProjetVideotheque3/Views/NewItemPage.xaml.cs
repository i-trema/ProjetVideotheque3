﻿using ProjetVideotheque3.Models;
using ProjetVideotheque3.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetVideotheque3.Views
{
    public partial class NewItemPage : ContentPage
    {
        //public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}