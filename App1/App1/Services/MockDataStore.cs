using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App1.Models;

[assembly: Xamarin.Forms.Dependency(typeof(App1.Services.MockDataStore))]
namespace App1.Services
{
    public class MockDataStore : IDataStore<Monument>
    {
        List<Monument> monuments;

        public MockDataStore()
        {
            monuments = DatabaseHelper.GetAll();

        }

        public async Task<bool> AddMonumentAsync(Monument Monument)
        {
            monuments.Add(Monument);
            DatabaseHelper.Insert(ref Monument);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMonumentAsync(Monument monument)
        {
            var _monument = monuments.Where((Monument arg) => arg.Id == monument.Id).FirstOrDefault();
            monuments.Remove(_monument);
            monuments.Add(monument);
            DatabaseHelper.Update(monument);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMonumentAsync(Monument monument)
        {
                var _monument = monuments.Where((Monument arg) => arg.Id == monument.Id).FirstOrDefault();
                monuments.Remove(_monument);
                DatabaseHelper.Delete(_monument);
                return await Task.FromResult(true);
        }

        public async Task<Monument> GetMonumentAsync(int id)
        {
            return await Task.FromResult(monuments.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Monument>> GetMonumentsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(monuments);
        }
    }
}