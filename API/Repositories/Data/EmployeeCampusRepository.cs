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
    public class EmployeeCampusRepository : ICampusEmployeeRepository
    {
        MyContext myContext;

        public EmployeeCampusRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.employeecampuses.Find(id);
            myContext.employeecampuses.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<EmployeeCampusViewModel> Get()
        {
            var data = myContext.employeecampuses.Select(x => new EmployeeCampusViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Address = x.Address,
                PositionId = x.PositionId
            }).ToList();

            return data;
        }

        public EmployeeCampusViewModel Get(int id)
        {
            var data = myContext.employeecampuses.Where(x => x.Id == id).Select(x => new EmployeeCampusViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Address = x.Address,
                PositionId = x.PositionId
            }).FirstOrDefault();
            return data;
        }

        public int Post(EmployeeCampusViewModel campus)
        {
            myContext.employeecampuses.Add(new EmployeeCampus
            {
                Name = campus.Name,
                Phone = campus.Phone,
                Address = campus.Address,
                PositionId = campus.PositionId
            });
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, EmployeeCampusViewModel campus)
        {
            var data = myContext.employeecampuses.Find(id);
            data.Name = campus.Name;
            data.Phone = campus.Phone;
            data.Address = campus.Address;
            data.PositionId = campus.PositionId;
            myContext.employeecampuses.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
