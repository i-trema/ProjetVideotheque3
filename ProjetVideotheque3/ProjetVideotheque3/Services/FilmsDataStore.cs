using ProjetVideotheque3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetVideotheque3.Services
{
    public class FilmsDataStore : IDataStore<Film>
    {

        readonly VideothequeDbContext db;


        public FilmsDataStore()
        {

            db = DependencyService.Get<VideothequeDbContext>();

        }
        #region FILMS 

        public async Task<bool> AddItemAsync(Film item)
        {
            await db.AddAsync(item);
            await db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateItemAsync(Film item)
        {
            var oldItem = db.Films.Where((Film arg) => arg.Id == item.Id).FirstOrDefault();
            db.Remove(oldItem);
            db.Add(item);
            await db.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = db.Films.Where((Film arg) => arg.Id.Equals(id)).FirstOrDefault();
            db.Remove(oldItem);
            await db.SaveChangesAsync();


            return await Task.FromResult(true);
        }


        public async Task<Film> GetItemAsync(int id)
        {
            return await Task.FromResult(db.Films.FirstOrDefault(s => s.Id.Equals(id)));
        }

        public Task<IEnumerable<Film>> GetItemsAsync(bool forceRefresh = false)
        {

            var dbSet = db.Set<Film>();
            if (dbSet == null)
                return null;

            return Task.FromResult(dbSet.AsEnumerable());
        }

        #endregion FILM

        public async Task<Models.Image> GetImagePrincipaleAsync(int filmId)
        {
            var img = db.Images.FirstOrDefault(i => (i.IdFilm == filmId) && i.EstImagePrincipale == true);



            return await Task.FromResult(img);
        }
    }
}
