using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericAPI.Domain.Repositories
{
    //Must be public
    public interface IUnitOfWork
    {
        //Method declared
        Task CompleteAsync();
    }
}
