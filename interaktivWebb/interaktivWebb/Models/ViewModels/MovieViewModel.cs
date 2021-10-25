﻿using interaktivWebb.Models.Dtos.Omdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktivWebb.Models.ViewModels
{
    public class MovieViewModel
    {
        public OmdbMovieDto movie { get; }
        public MovieDto cmdbMovie { get; }
        public MovieViewModel(OmdbMovieDto movie, MovieDto cmdbMovie)
        {
            this.movie = movie;
            this.cmdbMovie = cmdbMovie;
        }
    }
}