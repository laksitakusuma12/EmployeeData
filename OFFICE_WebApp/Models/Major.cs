﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OFFICE_WebApp.Models
{
    public class Major
    {
        [Key]
        public int Id { get; set; }
        public string MajorEmployee { get; set; }
    }
}
