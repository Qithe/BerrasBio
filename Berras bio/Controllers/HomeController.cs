﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BerrasBio.Models;
using Microsoft.EntityFrameworkCore;

namespace BerrasBio
{
    public class HomeController : Controller
    {
        private BerrasBioDBContext berrasBioDBContext;

        public HomeController(BerrasBioDBContext berrasBioDBContext)
        {
            this.berrasBioDBContext = berrasBioDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            var movie = await berrasBioDBContext.Movies.SingleOrDefaultAsync(m => m.Id == 1);

            ViewData["Message"] = movie.Title;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
