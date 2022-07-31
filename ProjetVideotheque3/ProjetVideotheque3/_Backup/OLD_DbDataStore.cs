using ProjetVideotheque3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ProjetVideotheque3.Services
{
    public class OLD_DbDataStore : IDataStore<Film>
    {
        readonly VideothequeDbContext db;
        

        public OLD_DbDataStore()
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




        #region IMAGES

        //public async Task<bool> AddItemAsync(Models.Image item)
        //{
        //    await db.AddAsync(item);
        //    await db.SaveChangesAsync();
        //    return true;

        //}

        //public async Task<bool> UpdateItemAsync(Models.Image item)
        //{
        //    var oldItem = db.Images.Where((Models.Image arg) => arg.Id == item.Id).FirstOrDefault();
        //    db.Remove(oldItem);
        //    db.Add(item);
        //    await db.SaveChangesAsync();

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> DeleteImageAsync(int id)
        //{
        //    var oldItem = db.Images.Where((Models.Image arg) => arg.Id.Equals(id)).FirstOrDefault();
        //    db.Remove(oldItem);
        //    await db.SaveChangesAsync();


        //    return await Task.FromResult(true);
        //}


        //public async Task<Models.Image> GetImageAsync(int id)
        //{
        //    return await Task.FromResult(db.Images.FirstOrDefault(s => s.Id.Equals(id)));
        //}

        //public Task<IEnumerable<Models.Image>> GetImagesAsync(bool forceRefresh = false)
        //{

        //    var dbSet = db.Set<Models.Image>();
        //    if (dbSet == null)
        //        return null;

        //    return Task.FromResult(dbSet.AsEnumerable());
        //}

        //#endregion IMAGES

        //#region PERSONNES
        //public Task<bool> AddItemAsync(Personne item)
        //{
        //    await db.AddAsync(item);
        //    await db.SaveChangesAsync();
        //    return true;
        //}

        //public async Task<bool> DeletePersonneAsync(int id)
        //{
        //    var oldItem = db.Personnes.Where((Personne arg) => arg.Id.Equals(id)).FirstOrDefault();
        //    db.Remove(oldItem);
        //    await db.SaveChangesAsync();


        //    return await Task.FromResult(true);
        //}
        //public Task<bool> UpdateItemAsync(Personne item)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<Personne> IDataStore<Personne>.GetItemAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IEnumerable<Personne>> IDataStore<Personne>.GetItemsAsync(bool forceRefresh)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion PERSONNES
    }
}