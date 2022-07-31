using ProjetVideotheque3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetVideotheque3.Services
{
    public class ImagesDataStore : IDataStore<Models.Image>
    {
        readonly VideothequeDbContext db;


        public ImagesDataStore()
        {

            db = DependencyService.Get<VideothequeDbContext>();

        }

        #region IMAGES

        public async Task<bool> AddItemAsync(Models.Image item)
        {
            await db.AddAsync(item);
            await db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateItemAsync(Models.Image item)
        {
            var oldItem = db.Images.Where((Models.Image arg) => arg.Id == item.Id).FirstOrDefault();
            db.Remove(oldItem);
            db.Add(item);
            await db.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = db.Images.Where((Models.Image arg) => arg.Id.Equals(id)).FirstOrDefault();
            db.Remove(oldItem);
            await db.SaveChangesAsync();


            return await Task.FromResult(true);
        }


        public async Task<Models.Image> GetItemAsync(int id)
        {
            return await Task.FromResult(db.Images.FirstOrDefault(s => s.Id.Equals(id)));
        }

        

        public Task<IEnumerable<Models.Image>> GetItemsAsync(bool forceRefresh = false)
        {

            var dbSet = db.Set<Models.Image>();
            if (dbSet == null)
                return null;

            return Task.FromResult(dbSet.AsEnumerable());
        }

        #endregion IMAGES
    }
}
