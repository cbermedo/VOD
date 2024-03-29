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
using VOD.Database.Services;

namespace VOD.UI.Controllers
{
    public class HomeController : Controller
    {

        //DI Login 
        private SignInManager<VODUser> _signInManager;

        //inyecto interfaz IDbReadService para recibir una instancia de DbReadService
        //cuando el usuario necesite una de estas vistas, se hace para modo de prueba, 
        //probando la funcionalidad en index async action
        //private IDbReadService _db;
        //private IUIReadService _db;

        //public HomeController(SignInManager<VODUser> signInMgr, IDbReadService db)
        //public HomeController(SignInManager<VODUser> signInMgr, IUIReadService db)
        public HomeController(SignInManager<VODUser> signInMgr)
        {
            _signInManager = signInMgr;
            //_db = db;
        }

        //public async Task<IActionResult> Index()
        //{
        //    //_db.Include<Download>();
        //    //_db.Include<Module, Course>();

        //    //// Get Single
        //    //var result1 = await _db.SingleAsync<Download>(d => d.Id.Equals(3));
        //    //// Fetch all
        //    //var result2 = await _db.GetAsync<Download>(); 
        //    //// Fetch all that matches the Lambda expression
        //    //var result3 = await _db.GetAsync<Download>(d => d.ModuleId.Equals(1));
        //    //// True if a record is found
        //    //var result4 = await _db.AnyAsync<Download>(d => d.ModuleId.Equals(1)); 
        //}

        //public async Task<IActionResult> Index() {
        //    var courses = (await _db.GetCourses("6cf38e83-ee7c-4184-b416-9d1888a6e8f1")).ToList();        //    var course = (await _db.GetCourse("6cf38e83-ee7c-4184-b416-9d1888a6e8f1", 1));        //    var video = await _db.GetVideo("6cf38e83-ee7c-4184-b416-9d1888a6e8f1", 1);        //    var videos = (await _db.GetVideos("6cf38e83-ee7c-4184-b416-9d1888a6e8f1", 1)).ToList();        //    return Ok();
        //}

        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
                return RedirectToPage("/Account/Login", new { Area = "Identity" });

            return RedirectToAction("Dashboard", "Membership");
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
