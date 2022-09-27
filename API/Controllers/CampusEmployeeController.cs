using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampusEmployeeController : ControllerBase
    {
        MyContext myContext;
        
        public CampusEmployeeController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        // READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.employeecampuses.ToList();
            if(data.Count == 0)
                return Ok(new { message = "sukses mengambil data", StatusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", StatusCode = 200, data = data });
            //return Ok(new { message = "sukses mengambil data", StatusCode = 200, data = data });
            //return BadRequest(new {message = "sukses mengambil data", StatusCode = 200, data = data });
            //return NotFound(new { message = "sukses mengambil data", StatusCode = 200, data = data });
            //return Unauthorized();
            //return Forbid();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.employeecampuses.Find(id);
            if (data == null)
                return Ok(new { message = "sukses mengambil data", StatusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", StatusCode = 200, data = data });
        }
        // UPDATE 
        [HttpPut]
        public IActionResult Put(EmployeeCampus employeeCampus)
        {
            var data = myContext.employeecampuses.Find(employeeCampus.Id);
            data.Name = employeeCampus.Name;
            myContext.employeecampuses.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil mengupdate data" });
            return BadRequest(new { StatusCode = 400, message = "gagal mengupdate data" });
        }
        // CREATE
        [HttpPost]
        public IActionResult Post(int id, EmployeeCampus employeeCampus)
        {
            myContext.employeecampuses.Add(employeeCampus);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menambah data" });
            return BadRequest(new { StatusCode = 400, message = "gagal menambah data" });
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.employeecampuses.Find(id);
            myContext.employeecampuses.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menghapus data" });
            return BadRequest(new { StatusCode = 400, message = "gagal menghapus data" });
        }
    }
}
