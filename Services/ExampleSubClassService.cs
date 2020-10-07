using GenericAPI.Domain.Models;
using GenericAPI.Domain.Repositories;
using GenericAPI.Domain.Services;
using GenericAPI.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Service
{
    public class ExampleSubClassService : IExampleSubClassService
    {
        private readonly IExampleSubClassRepository _exampleSubClassRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExampleSubClassService(IExampleSubClassRepository exampleSubClassRepository, IUnitOfWork unitOfWork)
        {
            _exampleSubClassRepository = exampleSubClassRepository;
            _unitOfWork = unitOfWork;
        }

        //Methods are declared here
        public async Task<ExampleSubClassResponse> DeleteAsync(int id)
        {
            var existingExampleSubClass = await _exampleSubClassRepository.FindById(id);
            if (existingExampleSubClass == null)
                return new ExampleSubClassResponse("ExampleSubClass not found");
            try
            {
                _exampleSubClassRepository.Remove(existingExampleSubClass);
                await _unitOfWork.CompleteAsync();
                return new ExampleSubClassResponse(existingExampleSubClass);
            }
            catch (Exception ex)
            {
                return new ExampleSubClassResponse($"An error ocurred while deleting ExampleSubClass: {ex.Message}");
            }
        }

        public async Task<ExampleSubClassResponse> GetByIdAsync(int id)
        {
            //Similar to first part of DeleteAsync
            var existingExampleSubClass = await _exampleSubClassRepository.FindById(id);
            if (existingExampleSubClass == null)
                return new ExampleSubClassResponse("ExampleSubClass not found");
            //Diferent from DeleteAsync
            return new ExampleSubClassResponse(existingExampleSubClass);
        }

        public async Task<IEnumerable<ExampleSubClass>> ListAsync()
        {
            return await _exampleSubClassRepository.ListAsync();
        }

        public async Task<ExampleSubClassResponse> SaveAsync(ExampleSubClass exampleSubClass)
        {
            try
            {
                await _exampleSubClassRepository.AddAsync(exampleSubClass);
                await _unitOfWork.CompleteAsync();
                return new ExampleSubClassResponse(exampleSubClass);
            }
            catch (Exception ex)
            {
                return new ExampleSubClassResponse($"An error ocurred while saving the ExampleSubClass: {ex.Message}");
            }
        }

        public async Task<ExampleSubClassResponse> UpdateAsync(int id, ExampleSubClass exampleSubClass)
        {
            //Similar to DeleteAsync
            var existingExampleSubClass = await _exampleSubClassRepository.FindById(id);
            if (existingExampleSubClass == null)
                return new ExampleSubClassResponse("ExampleSubClass not found");
            //Diferent from DeleteAsync
            existingExampleSubClass.Data = exampleSubClass.Data;
            try
            {
                //Diferent from DeleteAsync
                _exampleSubClassRepository.Update(existingExampleSubClass);
                await _unitOfWork.CompleteAsync();
                return new ExampleSubClassResponse(existingExampleSubClass);
            }
            catch (Exception ex)
            {
                return new ExampleSubClassResponse($"An error ocurred while deleting ExampleSubClass: {ex.Message}");
            }
        }
    }
}
