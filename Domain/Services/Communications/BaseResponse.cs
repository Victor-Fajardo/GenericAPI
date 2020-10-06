using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Domain.Services.Communications
{
    //Must be abstract
    //Generic Type -> <T>
    public abstract class BaseResponse<T>
    {
        //Response format is defined here
        public bool Succes { get; protected set; }
        public string Message { get; protected set; }
        public T Resource { get; set; }

        public BaseResponse(T resource)
        {
            Resource = resource;
            Succes = true;
            Message = string.Empty;
        }
        public BaseResponse(string message)
        {
            Succes = false;
            Message = message;
        }
    }
}
