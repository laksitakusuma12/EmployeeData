using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFFICE_WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

/*
 * Entity Framework Core 3.1 / 5 / 6
 * Entity Framework Core Sql Server
 * Entity Framework Core Tools
 * tiap entity harus memiliki versi yang sama
 * 
 * Code First : Entity Framework Core Tools utk migrasi, dari kode menjadi database
 * migrasikan supaya menjadi sebuah db yg ada di server, db yg tabel nya sesuai dengan model
 * Code first dilakukan saat tidak ada db trs di migrasi jd database
 * 
 * Database First, db ada, kode nya ga ada
 * aplikasi udah ada, mau ngedevelope tp gada model nya, jd migrasikan database ke model
 * menggunakan ADO.NET
 */
