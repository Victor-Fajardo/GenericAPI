using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Resource
{
    public class ExampleSubClassResource
    {
        //Attributes of the class are declared here
        //Same atributes as in Domain.Models
        public int Id { get; set; }
        public string Data { get; set; }

        public ExampleClassResource ExampleClass { get; set; }
    }
}
