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
    public class MajorRepository : IMajorRepository
    {
        MyContext myContext;
        public MajorRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.majors.Find(id);
            myContext.majors.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<MajorViewModel> Get()
        {
            var data = myContext.majors.Select(x => new MajorViewModel
            {
                Id = x.Id,
                MajorEmployee = x.MajorEmployee
            }).ToList();
            return data;
        }

        public MajorViewModel Get(int id)
        {
            var data = myContext.majors.Where(x => x.Id == id).Select(x => new MajorViewModel{
                Id = x.Id,
                MajorEmployee = x.MajorEmployee
            }).FirstOrDefault();
            return data;
        }

        public int Post(MajorViewModel major)
        {
            myContext.majors.Add(new Major
            {
                MajorEmployee = major.MajorEmployee
            });
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, MajorViewModel major)
        {
            var data = myContext.majors.Find(id);
            data.MajorEmployee = major.MajorEmployee;
            myContext.majors.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
