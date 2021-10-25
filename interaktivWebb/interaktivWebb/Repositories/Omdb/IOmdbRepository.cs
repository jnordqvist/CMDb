using interaktivWebb.Models.Dtos.Omdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktivWebb.Repositories.Omdb
{
    public interface IOmdbRepository
    {
        Task<OmdbMovieDto> GetMovieInformation(string imdbId);
        Task<OmdbMovieDto> GetMovieInformationByTitle(string title);
    }
}
