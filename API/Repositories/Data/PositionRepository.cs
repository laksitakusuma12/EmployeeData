using API.Context;
using API.Models;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var data = Get(id);
            myContext.positions.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Position> Get()
        {
            var data = myContext.positions.ToList();
            return data;
        }

        public Position Get(int id)
        {
            var data = myContext.positions.Find(id);
            return data;
        }

        public int Post(Position position)
        {
            myContext.positions.Add(position);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Position position)
        {
            var data = Get(position.Id);
            data.PositionEmployee = position.PositionEmployee;
            data.MajorId = position.MajorId;
            myContext.positions.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
