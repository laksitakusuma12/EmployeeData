using API.Context;
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
    public class PositionController : ControllerBase
    {
        MyContext myContext;

        public PositionController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        // READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.positions.Include(x => x.Major).ToList();
            if (data.Count == 0)
            {
                return Ok(new { message = "gagal mengambil data", StatusCode = 200, data = "null" });
            } else
            {
                return Ok(new { message = "sukses mengambil data", StatusCode = 200, data = data });
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.positions.Include(x => x.Major).Where(x => x.Id == id);
            if (data == null)
            {
                return Ok(new { message = "gagal mengambil data", StatusCode = 200, data = "null" });
            } else
            {
                return Ok(new { message = "sukses mengambil data", StatusCode = 200, data = data });
            }
        }
        // UPDATE 
        [HttpPut("{id}")]
        public IActionResult Put(int id, Position position)
        {
            var data = myContext.positions.Find(id);
            data.PositionEmployee = position.PositionEmployee;
            data.MajorId = position.MajorId;
            myContext.positions.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil mengupdate data" });
            return BadRequest(new { StatusCode = 400, message = "gagal mengupdate data" });
        }
        // CREATE
        [HttpPost]
        public IActionResult Post(Position position)
        {
            myContext.positions.Add(position);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menambah data" });
            return BadRequest(new { StatusCode = 400, message = "gagal menambah data" });
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.positions.Find(id);
            myContext.positions.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menghapus data" });
            return BadRequest(new { StatusCode = 400, message = "gagal menghapus data" });
        }
    }
}

