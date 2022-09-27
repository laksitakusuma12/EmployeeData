using API.Context;
using API.Models;
using API.Models.ViewModels;
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
    public class MajorController : ControllerBase
    {
        MyContext myContext;

        public MajorController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        // READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.majors.ToList();
            if (data.Count == 0)
                return Ok(new { message = "gagal mengambil data", StatusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", StatusCode = 200, data = data });
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.majors.Find(id);
            if (data == null)
                return Ok(new { message = "gagal mengambil data", StatusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", StatusCode = 200, data = data });
        }
        // UPDATE 
        [HttpPut("{id}")]
        public IActionResult Put(int id, Major major)
        {
            var data = myContext.majors.Find(id);
            data.MajorEmployee = major.MajorEmployee;
            myContext.majors.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil mengupdate data" });
            return BadRequest(new { StatusCode = 400, message = "gagal mengupdate data" });
        }
        // CREATE
        [HttpPost]
        public IActionResult Post(MajorViewModel major)
        {
            myContext.majors.Add(new Major
            {
                Id = major.Id,
                MajorEmployee = major.MajorEmployee
            });
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menambah data" });
            return BadRequest(new { StatusCode = 400, message = "gagal menambah data" });
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.majors.Find(id);
            myContext.majors.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menghapus data" });
            return BadRequest(new { StatusCode = 400, message = "gagal menghapus data" });
        }
    }
}

