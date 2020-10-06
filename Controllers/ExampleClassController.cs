using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GenericAPI.Domain.Models;
using GenericAPI.Domain.Services;
using GenericAPI.Extensions;
using GenericAPI.Resource;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GenericAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleClassController : ControllerBase
    {
        private readonly IExampleClassService _exampleClassService;
        private readonly IMapper _mapper;

        public ExampleClassController(IExampleClassService exampleClassService, IMapper mapper)
        {
            _exampleClassService = exampleClassService;
            _mapper = mapper;
        }

        // GET: api/<ExampleClassController>
        [HttpGet]
        public async Task<IEnumerable<ExampleClassResource>> GetAllAscyn()
        {
            var exampleClasses = await _exampleClassService.ListAsync();
            var resource = _mapper.Map<IEnumerable<ExampleClass>,
                IEnumerable<ExampleClassResource>>(exampleClasses);
            return resource;
        }

        // GET api/<ExampleClassController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExampleClassController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveExampleClassResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var exampleClass = _mapper.Map<SaveExampleClassResource, ExampleClass>(resource);

            var result = await _exampleClassService.SaveAsync(exampleClass);

            if (!result.Succes)
                return BadRequest(result.Message);
            var exampleClassResource = _mapper.Map<ExampleClass, ExampleClassResource>(result.Resource);
            return Ok(exampleClassResource);
        }


        // PUT api/<ExampleClassController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveExampleClassResource resource)
        {
            //Same as POST
            var exampleClass = _mapper.Map<SaveExampleClassResource, ExampleClass>(resource);

            //Diferent from POST
            var result = await _exampleClassService.UpdateAsync(id, exampleClass);

            if (!result.Succes)
                return BadRequest(result.Message);
            var exampleClassResource = _mapper.Map<ExampleClass, ExampleClassResource>(result.Resource);
            return Ok(exampleClassResource);
        }

            // DELETE api/<ExampleClassController>/5
            [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _exampleClassService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            //Same as POST
            var exampleClassResource = _mapper.Map<ExampleClass, ExampleClassResource>(result.Resource);
            return Ok(exampleClassResource);
        }
    }
}
