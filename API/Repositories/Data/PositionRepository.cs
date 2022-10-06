using API.Context;
using API.Models;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.ViewModels;

namespace API.Repositories.Data
{
    public class PositionRepository : IPositionRepository
    {
        MyContext myContext;
        public PositionRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.positions.Find(id);
            myContext.positions.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<PositionViewModel> Get()
        {
            var data = myContext.positions.Select(x => new PositionViewModel
            {
                Id = x.Id,
                PositionEmployee = x.PositionEmployee,
                MajorId = x.MajorId

            }).ToList();
            return data;
        }

        public PositionViewModel Get(int id)
        {
            var data = myContext.positions.Where(x => x.Id == id).Select(x => new PositionViewModel
            {
                Id = x.Id,
                PositionEmployee = x.PositionEmployee,
                MajorId = x.MajorId
            }).FirstOrDefault();
            return data;
        }

        public int Post(PositionViewModel position)
        {
            myContext.positions.Add(new Position
            {
                PositionEmployee = position.PositionEmployee,
                MajorId = position.MajorId
            });
            var result = myContext.SaveChanges();
            return result;
        }

        public int Post(Position position)
        {
            throw new NotImplementedException();
        }

        public int Put(int id, PositionViewModel position)
        {
            var data = myContext.positions.Find(id);
            data.PositionEmployee = position.PositionEmployee;
            data.MajorId = position.MajorId;
            myContext.positions.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
