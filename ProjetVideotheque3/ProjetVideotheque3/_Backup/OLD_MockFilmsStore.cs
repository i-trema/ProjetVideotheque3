using ProjetVideotheque3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetVideotheque3.Services
{
    public class OLD_MockFilmsStore : IDataStore<Film>
    {
        readonly List<Film> items;

        public OLD_MockFilmsStore()
        {
            items = new List<Film>()
            {
               new Film { Id = 1, Titre="The Dark Knight", DateSortie=DateTime.Today, LienBandeAnnonce="http://www.google.com", Note=2, Synopsis="Batmans Batman...."  },
                new Film { Id = 2, Titre = "Batman Begins" },
                new Film { Id = 3, Titre = "Joker" },
            };
        }

        public async Task<bool> AddItemAsync(Film item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Film item)
        {
            var oldItem = items.Where((Film arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Film arg) => arg.Id.Equals(id)).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Film> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id.Equals(id)));
        }

        public async Task<IEnumerable<Film>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}