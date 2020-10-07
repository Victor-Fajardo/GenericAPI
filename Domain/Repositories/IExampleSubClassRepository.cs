using GenericAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Domain.Repositories
{
    public interface IExampleSubClassRepository
    {
        //CRUD metohds are declared here
        Task<IEnumerable<ExampleSubClass>> ListAsync();
        Task AddAsync(ExampleSubClass exampleClass);
        Task<ExampleSubClass> FindById(int id);
        void Update(ExampleSubClass exampleClass);
        void Remove(ExampleSubClass exampleClass);
    }
}
