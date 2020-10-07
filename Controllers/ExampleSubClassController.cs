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
    public class ExampleSubClassController : ControllerBase
    {
        private readonly IExampleSubClassService _exampleSubClassService;
        private readonly IMapper _mapper;

        public ExampleSubClassController(IExampleSubClassService exampleSubClassService, IMapper mapper)
        {
            _exampleSubClassService = exampleSubClassService;
            _mapper = mapper;
        }

        // GET: api/<ExampleSubClassController>
        [HttpGet]
        public async Task<IEnumerable<ExampleSubClassResource>> GetAllAscyn()
        {
            var exampleSubClasses = await _exampleSubClassService.ListAsync();
            var resource = _mapper.Map<IEnumerable<ExampleSubClass>,
                IEnumerable<ExampleSubClassResource>>(exampleSubClasses);
            return resource;
        }

        // GET api/<ExampleSubClassController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExampleSubClassController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveExampleSubClassResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var exampleSubClass = _mapper.Map<SaveExampleSubClassResource, ExampleSubClass>(resource);

            var result = await _exampleSubClassService.SaveAsync(exampleSubClass);

            if (!result.Succes)
                return BadRequest(result.Message);
            var exampleSubClassResource = _mapper.Map<ExampleSubClass, ExampleSubClassResource>(result.Resource);
            return Ok(exampleSubClassResource);
        }

        // PUT api/<ExampleSubClassController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveExampleSubClassResource resource)
        {
            //Same as POST
            var exampleSubClass = _mapper.Map<SaveExampleSubClassResource, ExampleSubClass>(resource);

            //Diferent from POST
            var result = await _exampleSubClassService.UpdateAsync(id, exampleSubClass);

            if (!result.Succes)
                return BadRequest(result.Message);
            var exampleSubClassResource = _mapper.Map<ExampleSubClass, ExampleSubClassResource>(result.Resource);
            return Ok(exampleSubClassResource);
        }

        // DELETE api/<ExampleSubClassController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _exampleSubClassService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            //Same as POST
            var exampleSubClassResource = _mapper.Map<ExampleSubClass, ExampleSubClassResource>(result.Resource);
            return Ok(exampleSubClassResource);
        }
    }
}
