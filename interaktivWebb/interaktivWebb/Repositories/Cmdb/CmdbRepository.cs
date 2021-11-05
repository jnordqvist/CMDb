using interaktivWebb.Infrastructure;
using interaktivWebb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interaktivWebb.Repositories.Cmdb
{
    public class CmdbRepository : ICmdbRepository
    {
        private readonly IApiClient client;
        private readonly string baseUrl = "https://grupp9.dsvkurs.miun.se/api/";
        public CmdbRepository(IApiClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            var res = await client.GetAsync<IEnumerable<MovieDto>>($"{baseUrl}Toplist?count=10&type=popularity");
            return res;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMovies()
        {
            var res = await client.GetAsync<IEnumerable<MovieDto>>($"{baseUrl}Toplist");
            return res;
        }

        public async Task<MovieDto> GetMovie(string id)
        {
            var res = await client.GetAsync<MovieDto>($"{baseUrl}Movie/{id}");
            return res;
        }

        public Task<MovieDto> LikeMovie(string movieId)
        {
            throw new NotImplementedException();
        }
    }
}
