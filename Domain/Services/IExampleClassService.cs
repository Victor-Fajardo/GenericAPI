using GenericAPI.Domain.Models;
using GenericAPI.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Domain.Services
{
    //Must be public
    public interface IExampleClassService
    {
        //CRUD metohds are declared here
        Task<IEnumerable<ExampleClass>> ListAsync();
        Task<ExampleClassResponse> GetByIdAsync(int id);
        Task<ExampleClassResponse> SaveAsync(ExampleClass exampleClass);
        Task<ExampleClassResponse> UpdateAsync(int id, ExampleClass exampleClass);
        Task<ExampleClassResponse> DeleteAsync(int id);
    }
}
