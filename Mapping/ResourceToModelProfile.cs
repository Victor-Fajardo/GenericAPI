using AutoMapper;
using GenericAPI.Domain.Models;
using GenericAPI.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            //Create maps between Resources and Models
            CreateMap<SaveExampleClassResource, ExampleClass>();
            CreateMap<SaveExampleSubClassResource, ExampleSubClass>();
        }
    }
}
