using interaktivWebb.Models.ViewModels;
using interaktivWebb.Repositories.Cmdb;
using interaktivWebb.Repositories.Omdb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktivWebb.Controllers
{
    public class DetailPageController : Controller
    {
        private ICmdbRepository cmdbRepository;
        private IOmdbRepository omdbRepository;
        public DetailPageController(ICmdbRepository cmdbRepository, IOmdbRepository omdbRepository)
        {
            this.cmdbRepository = cmdbRepository;
            this.omdbRepository = omdbRepository;
        }
        public async Task<IActionResult> Movies(string id)
        {
            var test = id;

            var movieInformation =  await omdbRepository.GetMovieInformation(id);
            var cmdbMovie = await cmdbRepository.GetMovie(id);
            var model = new MovieViewModel(movieInformation, cmdbMovie);

            return View(model);
        }
    }
}
