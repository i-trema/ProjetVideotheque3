﻿using ProjetVideotheque3.Models;
using ProjetVideotheque3.Services;
using ProjetVideotheque3.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Image = ProjetVideotheque3.Models.Image;

namespace ProjetVideotheque3.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Film _selectedItem;

        
        public ObservableCollection<Film> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Film> ItemTapped { get; }

        readonly VideothequeDbContext db;


        public ItemsViewModel()
        {
            Title = "Liste des films";
            Items = new ObservableCollection<Film>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Film>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            db = DependencyService.Get<VideothequeDbContext>();
        }


        //async Task<Image> ImagePrincipale(Film film)
        //{
        //    Image imgPrinc = await Task.FromResult(db.Images.FirstOrDefault(i => ((i.IdFilm == film.Id) && i.EstImagePrincipale == true)));
        //    return imgPrinc;
        //}

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                
                foreach (var item in items)
                {
                        
                    
                    Items.Add(item);
                }
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Film SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Film item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }      
    }
}