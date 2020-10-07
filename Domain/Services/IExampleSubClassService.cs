using GenericAPI.Domain.Models;
using GenericAPI.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Domain.Services
{
    public interface IExampleSubClassService
    {
        //CRUD metohds are declared here
        Task<IEnumerable<ExampleSubClass>> ListAsync();
        Task<ExampleSubClassResponse> GetByIdAsync(int id);
        Task<ExampleSubClassResponse> SaveAsync(ExampleSubClass exampleSubClass);
        Task<ExampleSubClassResponse> UpdateAsync(int id, ExampleSubClass exampleSubClass);
        Task<ExampleSubClassResponse> DeleteAsync(int id);
    }
}
