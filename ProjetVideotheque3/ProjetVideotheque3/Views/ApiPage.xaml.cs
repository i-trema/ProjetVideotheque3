using ProjetVideotheque3.Models;
using ProjetVideotheque3.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetVideotheque3.Views
{
    public partial class ApiPage : ContentPage
    {
        //public Item Item { get; set; }

        public ApiPage()
        {
            InitializeComponent();
            
            BindingContext = new ApiViewModel();
        }

        private void Alert()
        {
            DisplayAlert("Titre non trouvé", "Ce titre de film n'a pas été trouvé dans la base de données IMDb", "Retour");
        }
            
    }
}