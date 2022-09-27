using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<EmployeeCampus> employeecampuses { get; set; }
        public DbSet<Position> positions { get; set; }
        public DbSet<Major> majors { get; set; }
    }
}
