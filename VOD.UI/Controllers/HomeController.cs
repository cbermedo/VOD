﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//Agregado para DI (dependency injection)
using VOD.UI.Models;
using Microsoft.AspNetCore.Identity;
using VOD.Common.Entities;

namespace VOD.UI.Controllers
{
    public class HomeController : Controller
    {

        //DI Login 
        private SignInManager<VODUser> _signInManager;
        public HomeController(SignInManager<VODUser> signInMgr)
        {
            _signInManager = signInMgr;
        }

        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
                return RedirectToPage("/Account/Login", new { Area = "Identity" });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
