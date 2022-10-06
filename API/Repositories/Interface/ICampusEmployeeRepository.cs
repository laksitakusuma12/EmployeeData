using API.Models;
using API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.ViewModels;

namespace API.Repositories.Interface
{
    interface ICampusEmployeeRepository
    {
        List<EmployeeCampusViewModel> Get();
        EmployeeCampusViewModel Get(int id);
        int Post(EmployeeCampusViewModel campus);
        int Put(int id, EmployeeCampusViewModel campus);
        int Delete(int id);
    }
}
