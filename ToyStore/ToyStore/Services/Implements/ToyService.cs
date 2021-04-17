using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyStore.Models;
using ToyStore.Repositories;

namespace ToyStore.Services.Implements
{
    public class ToyService : GenericService<Toy>, IToyService
    {
        private IToyRepository toyRepository;
        public ToyService(IToyRepository toyRepository):base(toyRepository)
        {
            this.toyRepository = toyRepository;
        }
    }
}
