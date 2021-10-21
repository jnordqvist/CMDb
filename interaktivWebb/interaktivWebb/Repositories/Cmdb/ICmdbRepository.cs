﻿using interaktivWebb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktivWebb.Repositories.Cmdb
{
    public interface ICmdbRepository
    {
        Task<IEnumerable<MovieDto>> GetMovies();
    }
}