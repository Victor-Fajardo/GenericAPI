using GenericAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Domain.Services.Communications
{
    public class ExampleSubClassResponse : BaseResponse<ExampleSubClass>
    {
        //Response methods are declared here
        public ExampleSubClassResponse(ExampleSubClass resource) : base(resource)
        { }
        public ExampleSubClassResponse(string message) : base(message)
        { }
    }
}
