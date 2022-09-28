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
    public class MajorRepository : IMajorRepository
    {
        MyContext myContext;
        public MajorRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = Get(id);
            myContext.majors.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Major> Get()
        {
            var data = myContext.majors.ToList();
            return data;
        }

        public Major Get(int id)
        {
            var data = myContext.majors.Find(id);
            return data;
        }

        public int Post(Major major)
        {
            myContext.majors.Add(major);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Major major)
        {
            var data = Get(major.Id);
            data.MajorEmployee = major.MajorEmployee;
            myContext.majors.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
