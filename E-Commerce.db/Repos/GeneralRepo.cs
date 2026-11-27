using E_Commerce.db.Base;
using E_Commerce.db.Context;
using E_Commerce.lib.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.db.Repos
{
    public class GeneralRepo<T>(AppDbContext appDb) : IGeneralRepo<T> where T : class
    {
        public async Task<int> AddAsync(T entity)
        {
            appDb.Set<T>().Add(entity);
            return await appDb.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await appDb.Set<T>().FindAsync(id);
            if (entity == null)
                throw new NotFoundException($"Item {id} Not Found");

            appDb.Set<T>().Remove(entity);
            return await appDb.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await appDb.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var item = await appDb.Set<T>().FindAsync(id);
            if (item == null)
                throw new NotFoundException($"Item {id} not found");
            return item;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            appDb.Set<T>().Update(entity);
            return await appDb.SaveChangesAsync();
        }
    }

}
