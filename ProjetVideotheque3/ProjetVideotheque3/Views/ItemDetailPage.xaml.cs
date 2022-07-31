using ProjetVideotheque3.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProjetVideotheque3.Views
{
    public partial class ItemDetailPage : ContentPage
    {

        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}