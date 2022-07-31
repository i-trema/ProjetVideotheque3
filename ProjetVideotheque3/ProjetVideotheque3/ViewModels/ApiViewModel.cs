using ProjetVideotheque3.Models;
using ProjetVideotheque3.Services;
using ProjetVideotheque3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetVideotheque3.ViewModels
{
    [QueryProperty(nameof(TitreAChercher), nameof(TitreAChercher))]
    [QueryProperty(nameof(IdToUpdate), nameof(IdToUpdate))]
    public class ApiViewModel : BaseViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private string iMDbId;
        private string titreAChercher;
        private string titre;
        private string synopsis;
        private int dureeMins;
        private string lienBandeAnnonce;
        private string imageUrl;
        private double iMDbNote;
        private int idToUpdate;

        public int IndexFilmResultats { get; set; }


        public ObservableCollection<ImdbFilm> Films { get; }

        public ImdbFilm ImdbFilm { get; set; }

        public Command LoadInfosFilmCommand { get; }
        public Command LoadFilmsCommand { get; }
        public string ApiKey { get; set; }

        public ApiViewModel() : base()
        {
            Title = "IMDb API";
            //Films = null;

            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            Films = new ObservableCollection<ImdbFilm>();
            LoadInfosFilmCommand = new Command(async () => await LoadFilmsAsync());

            //ImdbFilm = null;
            
            //LoadFilmsCommand = new Command(async () => await LoadFilmsAsync());

            //ApiKey = "k_y441bozk";
            ApiKey = "k_vhi9pzg2";

            IndexFilmResultats = 0; 
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
                
            }
        }

        public string IMDbId
        {
            get => iMDbId;
            set => SetProperty(ref iMDbId, value);
        }

        public string Titre
        {
            get => titre;
            set => SetProperty(ref titre, value);
        }

        public string TitreAChercher
        {
            get => titreAChercher;
            set => SetProperty(ref titreAChercher, value);
        }

        public string Synopsis
        {
            get => synopsis;
            set => SetProperty(ref synopsis, value);
        }

        public string LienBandeAnnonce
        {
            get => lienBandeAnnonce;
            set => SetProperty(ref lienBandeAnnonce, value);
        }

        public string ImageUrl
        {
            get => imageUrl;
            set => SetProperty(ref imageUrl, value);
        }

        public int DureeMins
        {
            get => dureeMins;
            set => SetProperty(ref dureeMins, value);
        }

        public double IMDbNote
        {
            get => iMDbNote;
            set => SetProperty(ref iMDbNote, value);
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(titreAChercher);
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }


        private async void OnSave()
        {
            Film itemToUpdate = new Film()
            {
                Id = IdToUpdate,
                Titre = Titre,
                Synopsis = Synopsis,
                Duree = DureeMins,
                LienBandeAnnonce = LienBandeAnnonce,
                IMDbNote = IMDbNote,
                Affiche = ImageUrl

            };
            await DataStore.UpdateItemAsync(itemToUpdate);

            //await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("../ItemsPage");
        }


        public async void LoadIMDbId(string idToLoad)
        {
            try
            {
                var res = await RestService.GetFilmAsync("https://imdb-api.com/fr/API/Title/" + ApiKey + "/" + idToLoad + "/Posters,Trailer,");

                //IMDbId = res.Id;
                Titre = res.Titre;
                Synopsis = res.Synopsis;
                DureeMins = res.DureeMins;
                LienBandeAnnonce = res.LienTrailer;
                IMDbNote = res.IMDbNote;
                ImageUrl = res.ImageUrl;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async Task LoadFilmsAsync()
        {
            IsBusy = true;

            try
            {

                Films.Clear();
                var films = await RestService.GetFilmsAsync("https://imdb-api.com/en/API/SearchMovie/" + ApiKey + "/" + TitreAChercher);
                //var films = await RestService.GetFilmsAsync("https://imdb-api.com/en/API/SearchMovie/k_y441bozk/Batman");
                if (films.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Titre non trouvé", "Ce titre de film n'a pas été trouvé dans la base de données IMDb", "Retour");
                }
                foreach (var film in films)
                    Films.Add(film);

                iMDbId = Films[IndexFilmResultats].Id;
                IndexFilmResultats++;

                LoadIMDbId(iMDbId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        //private async Task LoadInfosFilmAsync()
        //{
        //    IsBusy = true;

        //    try
        //    {
                
        //        var res = await RestService.GetFilmAsync("https://imdb-api.com/fr/API/Title/"+ApiKey+"/"+IMDbId+"/Posters,Trailer,") ;
        //        ImdbFilm = res;
                
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}
    }
}
