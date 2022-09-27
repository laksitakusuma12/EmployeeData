using OFFICE_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using OFFICE_WebApp.Context;
using Microsoft.EntityFrameworkCore;

namespace OFFICE_WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        MyContext myContext;

        public EmployeeController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        // READ
        public IActionResult Index()
        {
            var data = myContext.employeecampuses.Include(x => x.Position).Include(y => y.Position.Major).ToList();
            return View(data);
        }

        // READ BY ID
        // GET 
        public IActionResult Details(int id)
        {
            var data = myContext.employeecampuses.Include(x => x.Position).Include(y => y.Position.Major).ToList().Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }

        // CREATE
        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeCampus employeeCampus)
        {
            if (ModelState.IsValid)
            {
                myContext.employeecampuses.Include(x => x.Position).Include(y => y.Position.Major).ToList().Add(employeeCampus);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        // UPDATE
        // GET
        public IActionResult Edit(int id)
        {
            var data = myContext.employeecampuses.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeCampus employeeCampus)
        {
            if (ModelState.IsValid)
            {
                myContext.employeecampuses.Update(employeeCampus);
                var result = myContext.SaveChanges();
                if (result != 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        // DELETE
        // GET
        public IActionResult Delete(int id)
        {
            var data = myContext.employeecampuses.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EmployeeCampus employeeCampus)
        {
            if (ModelState.IsValid)
            {
                myContext.employeecampuses.Remove(employeeCampus);
                var result = myContext.SaveChanges();
                if (result != 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
