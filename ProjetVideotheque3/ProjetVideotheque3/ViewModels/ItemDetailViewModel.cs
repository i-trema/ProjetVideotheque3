using ProjetVideotheque3.Models;
using ProjetVideotheque3.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetVideotheque3.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        public Command EditItemCommand { get; }
        public Command DeleteItemCommand { get; }
        private int itemId;
        private string titre;
        private string synopsis;
        private DateTime dateSortie;
        private int duree;
        private string lienBandeAnnonce;
        private int note;
        private double iMDbNote;
        private string affiche;
        public int Id { get; set; }

        public string Titre
        {
            get => titre;
            set => SetProperty(ref titre, value);
        }

        public string Synopsis
        {
            get => synopsis;
            set => SetProperty(ref synopsis, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public DateTime DateSortie
        {
            get => dateSortie;
            set => SetProperty(ref dateSortie, value);
        }

        public int Duree
        {
            get => duree;
            set => SetProperty(ref duree, value);
        }

        public string LienBandeAnnonce
        {
            get => lienBandeAnnonce;    
            set => SetProperty(ref lienBandeAnnonce, value);
        }

        public string Affiche
        {
            get => affiche;
            set => SetProperty(ref affiche, value);
        }

        public int Note
        {
            get => note;
            set => SetProperty(ref note, value);
        }

        public double IMDbNote
        {
            get => iMDbNote;
            set => SetProperty(ref iMDbNote, value);
        }


        public ItemDetailViewModel()
        {
            Title = "Détails";
            
            

            EditItemCommand = new Command(OnEditItem);
            DeleteItemCommand = new Command(OnDeleteItem);
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Titre = item.Titre;
                Synopsis = item.Synopsis;
                DateSortie = item.DateSortie;
                Duree = item.Duree;
                LienBandeAnnonce = item.LienBandeAnnonce;
                Note = item.Note;
                IMDbNote = item.IMDbNote;
                Affiche = item.Affiche; 
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async void OnDeleteItem()
        {
            try
            {
                var item = await DataStore.DeleteItemAsync(itemId);

            }
            catch (Exception)
            {
                Debug.WriteLine("Film non trouvé");
            }

            await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");


        }



        async void OnEditItem()
        {
            await Shell.Current.GoToAsync($"{nameof(EditItemPage)}?{nameof(EditItemViewModel.IdToUpdate)}={Id}");
        }
    }
}
