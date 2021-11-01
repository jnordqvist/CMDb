using interaktivWebb.Models.Dtos.Omdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace interaktivWebb.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<OmdbMovieDto> Movies { get; }
        public IEnumerable<MovieDto> cmdbMovies { get; }
        public OmdbMovieDto TopMovie { get; }
        
        public HomeViewModel(List<OmdbMovieDto> movies, IEnumerable<MovieDto> cmdbMovies)
        {
            Movies = movies;
            this.cmdbMovies = cmdbMovies;
            TopMovie = movies[0];
        }
    }
}
