using interaktivWebb.Models;
using interaktivWebb.Models.Dtos.Omdb;
using interaktivWebb.Models.ViewModels;
using interaktivWebb.Repositories.Cmdb;
using interaktivWebb.Repositories.Omdb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace interaktivWebb.Controllers
{
    public class HomeController : Controller
    {

        private ICmdbRepository cmdbRepository;
        private IOmdbRepository omdbRepository;
        public HomeController(ICmdbRepository cmdbRepository, IOmdbRepository omdbRepository)
        {
            this.cmdbRepository = cmdbRepository;
            this.omdbRepository = omdbRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await getModel());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// hämtar data om filmer från cmdb och omdb, sorterar på numberOfLikes
        /// </summary>
        /// <returns></returns>
        private async Task<HomeViewModel> getModel()
        {
            var tasks = new List<Task>();
            var movies = await cmdbRepository.GetMovies();

            List<string> sortedMovies = new List<string>();

            var allMovies = new List<OmdbMovieDto>();

            foreach (var movie in movies)
            {
                tasks.Add(Task.Run(
                    async () =>
                    {
                        var result = await omdbRepository.GetMovieInformationById(movie.imdbID);
                        allMovies.Add(result);
                    }
                    ));
                sortedMovies.Add(movie.imdbID);
            }
            await Task.WhenAll(tasks);

            allMovies = allMovies.OrderBy(x => sortedMovies.IndexOf(x.imdbId)).ToList();
            return new HomeViewModel(allMovies, movies);
        }
    }
}
