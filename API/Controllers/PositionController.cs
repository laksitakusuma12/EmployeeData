using API.Context;
using API.Models;
using API.Repositories.Data;
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
        PositionRepository positionRepository;

        public PositionController(PositionRepository positionRepository)
        {
            this.positionRepository = positionRepository;
        }

        // READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = positionRepository.Get();
            if (data.Count == 0)
                return Ok(new { message = "gagal mengambil data", StatusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", StatusCode = 200, data = data });
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = positionRepository.Get();
            if (data == null)
                return Ok(new { message = "gagal mengambil data", StatusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", StatusCode = 200, data = data });
        }
        // UPDATE 
        [HttpPut("{id}")]
        public IActionResult Put(Position position)
        {
            var result = positionRepository.Put(position);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil mengupdate data" });
            return BadRequest(new { StatusCode = 400, message = "gagal mengupdate data" });
        }
        // CREATE
        [HttpPost]
        public IActionResult Post(Position position)
        {
            var result = positionRepository.Post(position);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menambah data" });
            return BadRequest(new { StatusCode = 400, message = "gagal menambah data" });
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = positionRepository.Delete(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menghapus data" });
            return BadRequest(new { StatusCode = 400, message = "gagal menghapus data" });
        }
    }
}

