using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface IMajorRepository
    {
        List<Major> Get();
        Major Get(int id);
        int Post(Major major);
        int Put(Major major);
        int Delete(int id);
    }
}
