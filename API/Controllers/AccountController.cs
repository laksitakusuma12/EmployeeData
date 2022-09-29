using API.Models.ViewModels;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        /*
         * Login
         * Register
         * Change Password
         * Forgot Password
         */

        // requirement login -> email & password
        // response login -> Id Karyawan, Email, Role (JWT -> JSON Web Token)
        // -> LoginVM -> LoginViewModels

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            var data = accountRepository.Login(login);
            if (data == null)
            {
                return BadRequest(new { message = "Gagal login! Email atau password salah", StatusCode = 400 });
            }
            return Ok(new { message = "Berhasil login!", StatusCode = 200, data = data });
        }

        [HttpPost("register")]
        public IActionResult Register(Register register)
        {
            var data = accountRepository.Register(register);
            if (data == null)
            {
                return BadRequest(new { message = "Gagal Register!", StatusCode = 400 });
            }
            return Ok(new { message = "Berhasil Register!", StatusCode = 200, data = data });
        }
    }
}
