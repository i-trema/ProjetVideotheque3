using ProjetVideotheque3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetVideotheque3.Services
{
    internal class PersonnesDataStore : IDataStore<Personne>
    {

        readonly VideothequeDbContext db;


        public PersonnesDataStore()
        {

            db = DependencyService.Get<VideothequeDbContext>();

        }

        #region PERSONNES 

        public async Task<bool> AddItemAsync(Personne item)
        {
            await db.AddAsync(item);
            await db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateItemAsync(Personne item)
        {
            var oldItem = db.Personnes.Where((Personne arg) => arg.Id == item.Id).FirstOrDefault();
            db.Remove(oldItem);
            db.Add(item);
            await db.SaveChangesAsync();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = db.Personnes.Where((Personne arg) => arg.Id.Equals(id)).FirstOrDefault();
            db.Remove(oldItem);
            await db.SaveChangesAsync();


            return await Task.FromResult(true);
        }


        public async Task<Personne> GetItemAsync(int id)
        {
            return await Task.FromResult(db.Personnes.FirstOrDefault(s => s.Id.Equals(id)));
        }

        public Task<IEnumerable<Personne>> GetItemsAsync(bool forceRefresh = false)
        {

            var dbSet = db.Set<Personne>();
            if (dbSet == null)
                return null;

            return Task.FromResult(dbSet.AsEnumerable());
        }

        #endregion PERSONNES
    }
}
