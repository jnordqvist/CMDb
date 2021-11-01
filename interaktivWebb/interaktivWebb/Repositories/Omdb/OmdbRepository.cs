using interaktivWebb.Infrastructure;
using interaktivWebb.Models.Dtos.Omdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktivWebb.Repositories.Omdb
{
    public class OmdbRepository : IOmdbRepository
    {
        private readonly IApiClient client;
        private readonly string key = "&apikey=f44c5f0a";
        private readonly string baseUrl = "http://www.omdbapi.com/?";

        public OmdbRepository(IApiClient client)
        {
            this.client = client;
        }

        public async Task<OmdbMovieDto> GetMovieInformationById(string imdbId)
        {
            var res = await client.GetAsync<OmdbMovieDto>($"{baseUrl}i={imdbId}{key}&plot=full");
            return res;
        }
        public async Task<OmdbMovieDto> GetMovieInformationByTitle(string title)
        {
            var res = await client.GetAsync<OmdbMovieDto>($"{baseUrl}t={title}{key}&plot=full");
            return res;
        }

    }
}
