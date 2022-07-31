using ProjetVideotheque3.ViewModels;
using ProjetVideotheque3.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ProjetVideotheque3
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(EditItemPage), typeof(EditItemPage));
            Routing.RegisterRoute(nameof(ApiPage), typeof(ApiPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));

        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    //await Shell.Current.GoToAsync("//LoginPage");
        //}
    }
}
