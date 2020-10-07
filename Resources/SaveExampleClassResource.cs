using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Resource
{
    public class SaveExampleClassResource
    {
        //Atributes declared here
        //Id is not used here
        //Class atributes from AppDbContext are specified here
        [Required]
        [MaxLength(20)]
        public string Data { get; set; }
    }
}
