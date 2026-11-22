using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.db.Base
{
    public interface IGeneralRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T>? GetByIdAsync(Guid id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(Guid id);
    }
}
