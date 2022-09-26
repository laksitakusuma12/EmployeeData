using OFFICE_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OFFICE_WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        SqlConnection sqlConnection;
        string connectionString = "Data Source=LAPTOP-DIV8R0C0\\MSSQLSERVER02;Initial Catalog=OFFICE;" +
            "User ID=laksita;Password=123;TrustServerCertificate=True;";
        public IActionResult Index(int id)
        {
            string query;
            if (id == 0)
            {
                query = "SELECT * FROM Employee";
            }
            else
            {
                query = $"SELECT * FROM Employee WHERE id = {id}";
            }
            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            List<Employee> Employee = new List<Employee>();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Employee employees = new Employee();
                            employees.Id = Convert.ToInt32(sqlDataReader[0]);
                            employees.Name = sqlDataReader[1].ToString();
                            employees.JobdeskId = Convert.ToInt32(sqlDataReader[2]);
                            Employee.Add(employees);
                        }
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(Employee);
        }
        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Employee " +
                        "(name, jobdeskid) " +
                        $"VALUES ('{employee.Name}', {employee.JobdeskId})";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return View();
            }
        }
        // UPDATE
        // GET
        public IActionResult Edit(int id)
        {
            string query = $"SELECT * FROM Employee WHERE id = {id}";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Employee employee = new Employee();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employee.Id = Convert.ToInt32(sqlDataReader[0]);
                            employee.Name = sqlDataReader[1].ToString();
                            employee.JobdeskId = Convert.ToInt32(sqlDataReader[2]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(employee);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "UPDATE Employee SET " +
                        $"name = '{employee.Name}', " +
                        $"jobdeskid = {employee.JobdeskId} " +
                        $"WHERE id = {employee.Id} ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Data Karyawan Sudah Diedit");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return View();
            }
        }
        // DELETE
        // GET
        public IActionResult Delete(int id)
        {
            string query = $"SELECT * FROM Employee WHERE id = {id}";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Employee employee = new Employee();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employee.Id = Convert.ToInt32(sqlDataReader[0]);
                            employee.Name = sqlDataReader[1].ToString();
                            employee.JobdeskId = Convert.ToInt32(sqlDataReader[2]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(employee);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "DELETE FROM Employee " +
                        $"WHERE id = {employee.Id}";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Data Karyawan Sudah Terhapus");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View();
        }

        // GET
        public IActionResult Details(int id)
        {
            string query = $"SELECT * FROM Employee WHERE id = {id}";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Employee employee = new Employee();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employee.Id = Convert.ToInt32(sqlDataReader[0]);
                            employee.Name = sqlDataReader[1].ToString();
                            employee.JobdeskId = Convert.ToInt32(sqlDataReader[2]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(employee);
        }
    }
}
