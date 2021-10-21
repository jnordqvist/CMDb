using interaktivWebb.Models;
using interaktivWebb.Repositories.Cmdb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace interaktivWebb.Controllers
{
    public class HomeController : Controller
    {

        private IRepository repository;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await repository.GetMovies();
            
            return View(movies);
        }

        
    }
}
