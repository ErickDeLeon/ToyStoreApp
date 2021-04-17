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
        private DbSet<TEntity> Table;
        public GenericRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
            Table = dataContext.Set<TEntity>();
        }
        public int Count()
        {
            return dataContext.Set<TEntity>().ToList().Count();
        }

        public async Task Delete(int id, TEntity entity)
        {     
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
            try
            {
                dataContext.Entry<TEntity>(entity).State = EntityState.Modified;
                await dataContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                return entity;
            }


        }
    }
}
