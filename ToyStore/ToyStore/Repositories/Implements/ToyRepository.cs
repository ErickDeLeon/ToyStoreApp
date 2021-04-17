using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyStore.Models;

namespace ToyStore.Repositories.Implements
{
    public class ToyRepository : GenericRepository<Toy>, IToyRepository
    {
        private readonly DataContext dataContext;
        public ToyRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
