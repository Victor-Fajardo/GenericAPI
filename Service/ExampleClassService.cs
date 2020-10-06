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
    public class ExampleClassService : IExampleClassService
    {
        private readonly IExampleClassRepository _exampleClassRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExampleClassService(IExampleClassRepository exampleClassRepository, IUnitOfWork unitOfWork)
        {
            _exampleClassRepository = exampleClassRepository;
            _unitOfWork = unitOfWork;
        }

        //Methods are declared here
        public async Task<ExampleClassResponse> DeleteAsync(int id)
        {
            var existingExampleClass = await _exampleClassRepository.FindById(id);
            if (existingExampleClass == null)
                return new ExampleClassResponse("ExampleClass not found");
            try
            {
                _exampleClassRepository.Remove(existingExampleClass);
                await _unitOfWork.CompleteAsync();
                return new ExampleClassResponse(existingExampleClass);
            }
            catch(Exception ex)
            {
                return new ExampleClassResponse($"An error ocurred while deleting ExampleClass: {ex.Message}");
            }
        }

        public async Task<ExampleClassResponse> GetByIdAsync(int id)
        {
            //Similar to first part of DeleteAsync
            var existingExampleClass = await _exampleClassRepository.FindById(id);
            if (existingExampleClass == null)
                return new ExampleClassResponse("ExampleClass not found");
            //Diferent from DeleteAsync
            return new ExampleClassResponse(existingExampleClass);
        }

        public async Task<IEnumerable<ExampleClass>> ListAsync()
        {
            return await _exampleClassRepository.ListAsync();
        }

        public async Task<ExampleClassResponse> SaveAsync(ExampleClass exampleClass)
        {
            try
            {
                await _exampleClassRepository.AddAsync(exampleClass);
                await _unitOfWork.CompleteAsync();
                return new ExampleClassResponse(exampleClass);
            }
            catch (Exception ex)
            {
                return new ExampleClassResponse($"An error ocurred while saving the ExampleClass: {ex.Message}");
            }
        }

        public async Task<ExampleClassResponse> UpdateAsync(int id, ExampleClass exampleClass)
        {
            //Similar to DeleteAsync
            var existingExampleClass = await _exampleClassRepository.FindById(id);
            if (existingExampleClass == null)
                return new ExampleClassResponse("ExampleClass not found");
            //Diferent from DeleteAsync
            existingExampleClass.Data = exampleClass.Data;
            try
            {
                //Diferent from DeleteAsync
                _exampleClassRepository.Update(existingExampleClass);
                await _unitOfWork.CompleteAsync();
                return new ExampleClassResponse(existingExampleClass);
            }
            catch (Exception ex)
            {
                return new ExampleClassResponse($"An error ocurred while deleting ExampleClass: {ex.Message}");
            }
        }
    }
}
