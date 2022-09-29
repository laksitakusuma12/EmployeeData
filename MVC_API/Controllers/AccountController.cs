using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using MVC_API.Models.ViewModel;

namespace MVC_API.Controllers
{
    public class AccountController : Controller
    {
        /*
         * Login
         * Register
         * Change Password
         * Forgot Password
         */

        HttpClient HttpClient;

        public AccountController()
        {

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            string address = "https://localhost:44336/api/Account/login";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", data.Data.Role);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            string address = "https://localhost:44336/api/Account/register";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClient2>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", data.Data.Role);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
