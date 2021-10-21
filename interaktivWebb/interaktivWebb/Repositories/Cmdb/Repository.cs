using interaktivWebb.Infrastructure;
using interaktivWebb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interaktivWebb.Repositories.Cmdb
{
    public class Repository : IRepository
    {
        private readonly IApiClient client;
        private readonly string baseUrl = "https://grupp9.dsvkurs.miun.se/api/";
        public Repository(IApiClient client)
        {
            this.client = client;
        }

        public async Task<List<MovieDto>> GetMovies()
        {
            var res = await client.GetAsyncList<MovieDto>($"{baseUrl}Movie");
            return res;
        }
    }
}
