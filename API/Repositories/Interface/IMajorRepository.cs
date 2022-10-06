using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.ViewModels;

namespace API.Repositories.Interface
{
    interface IMajorRepository
    {
        List<MajorViewModel> Get();
        MajorViewModel Get(int id);
        int Post(MajorViewModel major);
        int Put(int id, MajorViewModel major);
        int Delete(int id);
    }
}
