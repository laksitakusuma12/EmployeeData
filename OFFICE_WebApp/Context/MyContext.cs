using Microsoft.EntityFrameworkCore;
using OFFICE_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFFICE_WebApp.Context
{
    public class MyContext : DbContext
    {
        /*
         * Feature IdentityDbContext
         * - Login
         * - Register 
         * - Forgot Password
         * - Change Password
         * - Lockout Account (salah 3x maka akunnya dikunci gabisa login)
         * - Password nya udah di hash
         * 
         * Table
         * - Role
         * - User
         * - UserRole
         * - Claim
         * - UserClaim
         */

        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {
            /*
             * Context
             * DbContext menggunakan library using Microsoft.EntityFrameworkCore
             * perintahnya ada insert, update, delete, get all
             * 
             * MyContext digunakan utk menghubungkan aplikasi yg dibikin dengan database
             */

            // Atur connection string dalam startup.cs bagian ConfigureService,
            // menghubungkan context yg sdh dibuat disini dengan connection string yg ada di Controller
            // Memasukan model yg digunakan untuk melakukan operasi CRUD / Migrasi
        }
        public DbSet<EmployeeCampus> employeecampuses { get; set; }
        public DbSet<Position> positions { get; set; }
        public DbSet<Major> majors { get; set; }
    }
}
