﻿using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var data = myContext.employeecampuses.Include(x => x.Position).Include(y => y.Position.Major).ToList();
            if(data.Count == 0)
                return Ok(new { message = "gagal mengambil data", StatusCode = 200, data = "null" });
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
            var data = myContext.employeecampuses.Include(x => x.Position).Include(y => y.Position.Major).Where(x => x.Id == id);
            if (data == null)
                return Ok(new { message = "gagal mengambil data", StatusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", StatusCode = 200, data = data });
        }
        // UPDATE 
        [HttpPut("{id}")]
        public IActionResult Put(int id, EmployeeCampus employeeCampus)
        {
            var data = myContext.employeecampuses.Find(id);
            data.Name = employeeCampus.Name;
            data.Phone = employeeCampus.Phone;
            data.Address = employeeCampus.Address;
            data.PositionId = employeeCampus.PositionId;
            myContext.employeecampuses.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil mengupdate data" });
            return BadRequest(new { StatusCode = 400, message = "gagal mengupdate data" });
        }
        // CREATE
        [HttpPost]
        public IActionResult Post(EmployeeCampus employeeCampus)
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
