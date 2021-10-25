using interaktivWebb.Models.ViewModels;
using interaktivWebb.Repositories.Cmdb;
using interaktivWebb.Repositories.Omdb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            Regex reg = new Regex("^(tt[0-9]{7})$");
            if (reg.IsMatch(id))
            {
                var movieInformation = await omdbRepository.GetMovieInformation(id);
                var cmdbMovie = await cmdbRepository.GetMovie(id);
                var model = new MovieViewModel(movieInformation, cmdbMovie);
                return View(model);
            }
            else
            {
                string title = id.Replace(" ", "+");
                var movieInformation = await omdbRepository.GetMovieInformationByTitle(title);
                var cmdbMovie = await cmdbRepository.GetMovie(movieInformation.imdbId);
                var model = new MovieViewModel(movieInformation, cmdbMovie);
                return View(model);
            }

        }
    }
}
