using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Domain.Models
{
    public class ExampleSubClass
    {
        public int Id { get; set; }
        public string Data { get; set; }

        //Declare ExampleSubClass as a list inside ExampleClass
        public int ExampleClassId { get; set; }
        public ExampleClass ExampleClass { get; set; }
    }
}
