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
    public class EmployeeCampusRepository : ICampusEmployeeRepository
    {
        MyContext myContext;

        public EmployeeCampusRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = Get(id);
            myContext.employeecampuses.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<EmployeeCampus>Get()
        {
            var data = myContext.employeecampuses.Include(x => x.Position).Include(y => y.Position.Major).ToList();
            return data;
        }

        public EmployeeCampus Get(int id)
        {
            var data = myContext.employeecampuses.Find(id);
            return data;
        }

        public int Post(EmployeeCampus employeeCampus)
        {
            myContext.employeecampuses.Add(employeeCampus);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(EmployeeCampus employeeCampus)
        {
            var data = Get(employeeCampus.Id);
            data.Name = employeeCampus.Name;
            data.Phone = employeeCampus.Phone;
            data.Address = employeeCampus.Address;
            data.PositionId = employeeCampus.PositionId;
            myContext.employeecampuses.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
