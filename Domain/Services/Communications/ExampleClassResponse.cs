using GenericAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Domain.Services.Communications
{
    public class ExampleClassResponse : BaseResponse<ExampleClass>
    {
        //Response methods are declared here
        public ExampleClassResponse(ExampleClass resource) : base(resource)
        { }
        public ExampleClassResponse(string message) : base(message)
        { }
    }
}
