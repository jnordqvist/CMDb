using interaktivWebb.Models.Dtos.Omdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interaktivWebb.Models.ViewModels
{
    public class GenreViewModel
    {
        public string Genre { get; set; }
        public List<OmdbMovieDto> filteredOmdbMovies { get; set; } = new List<OmdbMovieDto>();
        public List<MovieDto> filteredCmdbMovies { get; set; } = new List<MovieDto>();
        public GenreViewModel(List<OmdbMovieDto> omdbMovies, IEnumerable<MovieDto> cmdbMovies, string targetGenre)
        {
            Genre = targetGenre;
            foreach (var movie in omdbMovies)
            {
                var genreList = movie.genre.Split(", ").ToList();
                foreach (var currentGenre in genreList)
                {
                    if (currentGenre == targetGenre)
                    {
                        filteredOmdbMovies.Add(movie);
                        filteredCmdbMovies.Add(cmdbMovies.Where(x => x.imdbID == movie.imdbId).First());
                        break;
                    }
                }
            }
        }
    }
}
