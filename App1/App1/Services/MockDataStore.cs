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
            monuments = new List<Monument>();
            var mockMonuments = new List<Monument>
            {
                new Monument { Id = Guid.NewGuid().ToString(), Name = "First Monument", Description="This is an Monument description.", Location = "lokalizacja" },
                new Monument { Id = Guid.NewGuid().ToString(), Name = "Second Monument", Description="This is an Monument description.", Location = "lokaliazcja"},
                new Monument { Id = Guid.NewGuid().ToString(), Name = "Third Monument", Description="This is an Monument description." , Location = "lokalizacja"},
                new Monument { Id = Guid.NewGuid().ToString(), Name = "Fourth Monument", Description="This is an Monument description.", Location = "lokalizacja" },
                new Monument { Id = Guid.NewGuid().ToString(), Name = "Fifth Monument", Description="This is an Monument description." , Location = "lokalizacja"},
                new Monument { Id = Guid.NewGuid().ToString(), Name = "Sixth Monument", Description="This is an Monument description.", Location = "lokalizacja" },
            };

            foreach (var Monument in mockMonuments)
            {
                monuments.Add(Monument);
            }
        }

        public async Task<bool> AddMonumentAsync(Monument Monument)
        {
            monuments.Add(Monument);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMonumentAsync(Monument monument)
        {
            var _monument = monuments.Where((Monument arg) => arg.Id == monument.Id).FirstOrDefault();
            monuments.Remove(_monument);
            monuments.Add(monument);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMonumentAsync(Monument monument)
        {
            var _monument = monuments.Where((Monument arg) => arg.Id == monument.Id).FirstOrDefault();
            monuments.Remove(_monument);

            return await Task.FromResult(true);
        }

        public async Task<Monument> GetMonumentAsync(string id)
        {
            return await Task.FromResult(monuments.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Monument>> GetMonumentsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(monuments);
        }
    }
}