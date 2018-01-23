using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App1.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddMonumentAsync(T item);
        Task<bool> UpdateMonumentAsync(T item);
        Task<bool> DeleteMonumentAsync(T item);
        Task<T> GetMonumentAsync(string id);
        Task<IEnumerable<T>> GetMonumentsAsync(bool forceRefresh = false);
    }
}
