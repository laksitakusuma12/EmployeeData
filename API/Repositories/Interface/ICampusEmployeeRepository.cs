using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface ICampusEmployeeRepository
    {
        List<EmployeeCampus> Get();
        EmployeeCampus Get(int id);
        int Post(EmployeeCampus employeeCampus);
        int Put(EmployeeCampus employeeCampus);
        int Delete(int id);
    }
}
