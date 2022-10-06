using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.ViewModels;

namespace API.Repositories.Interface
{
    interface IPositionRepository
    {
        List<PositionViewModel> Get();
        PositionViewModel Get(int id);
        int Post(PositionViewModel position);
        int Put(int id, PositionViewModel position);
        int Delete(int id);
    }
}
