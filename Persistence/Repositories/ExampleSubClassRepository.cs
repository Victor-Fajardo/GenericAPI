using GenericAPI.Domain.Models;
using GenericAPI.Domain.Persistence.Contexts;
using GenericAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Persistence.Repositories
{
    public class ExampleSubClassRepository : BaseRepository, IExampleSubClassRepository
    {
        public ExampleSubClassRepository(AppDbContext context) : base(context)
        { }

        //CRUD methods implemented
        public async Task AddAsync(ExampleSubClass exampleClass)
        {
            await _context.ExampleSubClasses.AddAsync(exampleClass);
        }

        public async Task<ExampleSubClass> FindById(int id)
        {
            return await _context.ExampleSubClasses.FindAsync(id);
        }

        public async Task<IEnumerable<ExampleSubClass>> ListAsync()
        {
            return await _context.ExampleSubClasses.ToListAsync();
        }

        public void Remove(ExampleSubClass exampleClass)
        {
            _context.ExampleSubClasses.Remove(exampleClass);
        }

        public void Update(ExampleSubClass exampleClass)
        {
            _context.ExampleSubClasses.Update(exampleClass);
        }
    }
}
