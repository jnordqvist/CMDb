using interaktivWebb.Models.Dtos.Omdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktivWebb.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<OmdbMovieDto> Movies { get; set; }
        public IEnumerable<MovieDto> cmdbMovies { get; set; }

        public HomeViewModel(List<OmdbMovieDto> movies, IEnumerable<MovieDto> cmdbMovies)
        {
            Movies = movies;
            this.cmdbMovies = cmdbMovies;


        }
    }
}
