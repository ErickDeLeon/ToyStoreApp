using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyStore.Models;

namespace ToyStore.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DataContext dataContext;

        public GenericRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public int Count()
        {
            return dataContext.Set<TEntity>().ToList().Count();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
                throw new Exception("No existe");

            dataContext.Set<TEntity>().Remove(entity);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dataContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await dataContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await dataContext.Set<TEntity>().AddAsync(entity);
            await dataContext.SaveChangesAsync();
            return entity;

        }

        public async Task<TEntity> Update(int id, TEntity entity)
        {
            dataContext.Update<TEntity>(entity);
            dataContext.Entry(entity).CurrentValues.SetValues(entity);
            dataContext.Entry<TEntity>(entity).State = EntityState.Modified;
            //await dataContext.Set<TEntity>().AddOrUpdate(entity);
            await dataContext.SaveChangesAsync();
            return entity;
        }
    }
}
