﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GONIS.ReactRedux.Models;
using System.Net.Http;

namespace GONIS.ReactRedux.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public string Error() => "Error";
    }
}
