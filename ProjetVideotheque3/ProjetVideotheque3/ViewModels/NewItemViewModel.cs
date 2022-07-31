using ProjetVideotheque3.Models;
using ProjetVideotheque3.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetVideotheque3.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string titre;
        private string synopsis;
        private int idToUpdate;
        private DateTime dateSortie;
        private int duree;
        private string lienBandeAnnonce;
        private int note;
       
        private string affiche;
        //private List<int> notesList;

        private Random random = new Random();
        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            IMDbApiCommand = new Command(IMDbApi);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            NotesList = new List<int>() { 1, 2, 3, 4, 5 };
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(titre)
                /*&& !String.IsNullOrWhiteSpace(synopsis)*/;
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

        //public double IMDbNote
        //{
        //    get => iMDbNote;
        //    set => SetProperty(ref iMDbNote, value);
        //}

        public int IdToUpdate
        {
            get => note;
            set => SetProperty(ref note, value);
        }


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command IMDbApiCommand { get; }


        async void IMDbApi()
        {
            Film newItem = new Film()
            {
                Id = random.Next(1, 1000),
                Titre = Titre,
                Synopsis = Synopsis,
                DateSortie = DateSortie,
                Duree = Duree,
                LienBandeAnnonce = LienBandeAnnonce,
                Note = Note
                
                
            };


            await DataStore.AddItemAsync(newItem);
            await Shell.Current.GoToAsync($"{nameof(ApiPage)}?{nameof(ApiViewModel.TitreAChercher)}={Titre}&{nameof(ApiViewModel.IdToUpdate)}={newItem.Id}");

        }
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Film newItem = new Film()
            {

                
                Id =  random.Next(1,1000),
                Titre = Titre,
                Synopsis = Synopsis,
                DateSortie = DateSortie,
                Duree = Duree,
                LienBandeAnnonce = LienBandeAnnonce,
                Note = Note
                
            };

            newItem.Images.Add(new Models.Image { EstImagePrincipale = true, ImageUrl = Affiche, IdFilm = newItem.Id });


            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
