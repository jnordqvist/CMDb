using interaktivWebb.Models.Dtos.Omdb;
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
    public class FilterController : Controller
    {
        private ICmdbRepository cmdbRepository;
        private IOmdbRepository omdbRepository;
        public FilterController(ICmdbRepository cmdbRepository, IOmdbRepository omdbRepository)
        {
            this.cmdbRepository = cmdbRepository;
            this.omdbRepository = omdbRepository;
        }

        /// <summary>
        /// hämtar filmer baserat på skådespelare
        /// </summary>
        /// <param name="id">vald skådespelare</param>
        /// <returns></returns>
        public async Task<IActionResult> Actor(string id)
        {
            var tasks = new List<Task>();
            var movies = await cmdbRepository.GetAllMovies();

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
            var model = new ActorViewModel(allMovies, movies, id);
            return View(model);
        }

        /// <summary>
        /// hämtar filmer baserat på genre
        /// </summary>
        /// <param name="id">vald genre</param>
        /// <returns></returns>
        public async Task<IActionResult> Genre(string id)
        {
            var tasks = new List<Task>();
            var movies = await cmdbRepository.GetAllMovies();

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
            var model = new GenreViewModel(allMovies, movies, id);
            
            return View(model);
        }

    }
}
