﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Domain.Models
{
    public class ExampleClass
    {
        public int Id { get; set; }
        public string Data { get; set; }

        //Declaron ExampleSubClass as a list inside ExampleClass
        public IList<ExampleSubClass> ExampleSubClasses { get; set; } = new List<ExampleSubClass>();
    }
}
