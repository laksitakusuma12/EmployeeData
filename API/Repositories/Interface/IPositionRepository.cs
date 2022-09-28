using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface IPositionRepository
    {
        List<Position> Get();
        Position Get(int id);
        int Post(Position position);
        int Put(Position position);
        int Delete(int id);
    }
}
