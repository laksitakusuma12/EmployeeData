﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_API.Models.ViewModel
{
    public class ResponseClient
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public ResponseLogin Data { get; set; }
    }
}
