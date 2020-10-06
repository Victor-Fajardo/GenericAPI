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
    public class ExampleClassRepository : BaseRepository, IExampleClassRepository
    {
        public ExampleClassRepository(AppDbContext context) : base(context)
        { }

        //CRUD methods implemented
        public async Task AddAsync(ExampleClass exampleClass)
        {
            await _context.ExampleClasses.AddAsync(exampleClass);
        }

        public async Task<ExampleClass> FindById(int id)
        {
            return await _context.ExampleClasses.FindAsync(id);
        }

        public async Task<IEnumerable<ExampleClass>> ListAsync()
        {
            return await _context.ExampleClasses.ToListAsync();
        }

        public void Remove(ExampleClass exampleClass)
        {
            _context.ExampleClasses.Remove(exampleClass);
        }

        public void Update(ExampleClass exampleClass)
        {
            _context.ExampleClasses.Update(exampleClass);
        }
    }
}
