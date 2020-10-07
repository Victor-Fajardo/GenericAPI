using AutoMapper;
using GenericAPI.Domain.Models;
using GenericAPI.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            //Create maps between Models and Resources
            CreateMap<ExampleClass, ExampleClassResource>();
            CreateMap<ExampleSubClass, ExampleSubClassResource>();
        }
    }
}
