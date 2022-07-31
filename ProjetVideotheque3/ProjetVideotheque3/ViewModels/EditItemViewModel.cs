using ProjetVideotheque3.Models;
using ProjetVideotheque3.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetVideotheque3.ViewModels
{
    [QueryProperty(nameof(IdToUpdate), nameof(IdToUpdate))]
    public class EditItemViewModel : BaseViewModel
    {

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command IMDbApiCommand { get; }


        private string titre;
        private string synopsis;
        private int idToUpdate;
        private DateTime dateSortie;
        private int duree;
        private string lienBandeAnnonce;
        private int note;
        private string affiche;
        private Genre genre;
        //private List<int> notesList;
        public int Id { get; set; }
        
        public Genre Genre 
        {
            get => genre;
            set => SetProperty(ref genre, value); 
        }
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

        public int IdToUpdate
        {
            get
            {
                return idToUpdate;
            }
            set
            {
                idToUpdate = value;
                LoadItemId(value);
            }
        }

        public List<int> NotesList { get; set; }

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



        public EditItemViewModel()
        {
            Title = "Modifier";

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            IMDbApiCommand = new Command(IMDbApi);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            NotesList = new List<int>() { 1,2,3, 4, 5 };
        }



        

        public async void LoadItemId(int idToUpdate)
        {
            try
            {
                Film item = await DataStore.GetItemAsync(idToUpdate);
                //Id = item.Id;
                Titre = item.Titre;
                Synopsis = item.Synopsis;
                DateSortie = item.DateSortie;
                Duree = item.Duree;
                LienBandeAnnonce = item.LienBandeAnnonce;
                Note = item.Note;
                Affiche = item.Affiche;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        async void IMDbApi()
        {            
            await Shell.Current.GoToAsync($"{nameof(ApiPage)}?{nameof(ApiViewModel.TitreAChercher)}={Titre}&{nameof(ApiViewModel.IdToUpdate)}={IdToUpdate}");
            
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(titre)
                /*&& !String.IsNullOrWhiteSpace(synopsis)*/;
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            //Film itemToUpdate = await DataStore.GetItemAsync(IdToUpdate);
            Film itemToUpdate = new Film()
            {
                Id = IdToUpdate,
                Titre = Titre,
                Synopsis = Synopsis,
                DateSortie = DateSortie,
                Duree = Duree,
                LienBandeAnnonce = LienBandeAnnonce,
                Note = Note,
                Affiche = Affiche

        };
            
            await DataStore.UpdateItemAsync(itemToUpdate);

            

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
