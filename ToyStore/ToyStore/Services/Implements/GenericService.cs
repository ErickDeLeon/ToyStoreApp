using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyStore.Repositories;

namespace ToyStore.Services.Implements
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {

        private IGenericRepository<TEntity> genericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task Delete(int id, TEntity entity)
        {
            await genericRepository.Delete(id, entity);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await genericRepository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await genericRepository.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await genericRepository.Insert(entity);
        }

        public async Task<TEntity> Update(int id, TEntity entity)
        {
            return await genericRepository.Update(id, entity);
        }
    }
}
