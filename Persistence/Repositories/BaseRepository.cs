using GenericAPI.Domain.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Persistence.Repositories
{
    //Must be abstract
    public abstract class BaseRepository
    {
        //AppDbContext object created
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
