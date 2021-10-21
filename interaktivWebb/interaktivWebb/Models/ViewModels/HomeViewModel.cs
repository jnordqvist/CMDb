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
        public HomeViewModel(List<OmdbMovieDto> movies)
        {
            Movies = movies;
        }
    }
}
