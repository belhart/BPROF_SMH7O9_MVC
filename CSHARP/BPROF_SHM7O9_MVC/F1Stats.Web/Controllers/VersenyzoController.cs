﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace F1Stats.Web.Controllers
{
    public class VersenyzoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}