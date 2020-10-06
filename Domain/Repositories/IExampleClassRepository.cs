using GenericAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Domain.Repositories
{
    //Must be public
    public interface IExampleClassRepository
    {
        //CRUD metohds are declared here
        Task<IEnumerable<ExampleClass>> ListAsync();
        Task AddAsync(ExampleClass exampleClass);
        Task<ExampleClass> FindById(int id);
        void Update(ExampleClass exampleClass);
        void Remove(ExampleClass exampleClass);
    }
}
