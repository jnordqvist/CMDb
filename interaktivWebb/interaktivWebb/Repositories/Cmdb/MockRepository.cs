using interaktivWebb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace interaktivWebb.Repositories.Cmdb
{

    public class MockRepository : ICmdbRepository
    {
        private readonly string basePath;

        public MockRepository(IWebHostEnvironment environment)
        {
            basePath = $@"{environment.ContentRootPath}\Mock\";
        }

        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            await Task.Delay(0);
            return GetTestData<IEnumerable<MovieDto>>("response.json");
        }

        
        public async Task<MovieDto> LikeMovie(string movieId)
        {
            await Task.Delay(0);
            var data = GetTestData<List<MovieDto>>("response.json");
            data.Where(x => x.imdbID == movieId).FirstOrDefault().numberOfLikes++;
            File.WriteAllText($"{basePath}response.json", JsonConvert.SerializeObject(data));
            return data.Where(x => x.imdbID == movieId).FirstOrDefault();
        }

        private T GetTestData<T>(string testfile)
        {
            var path = $"{basePath}{testfile}";
            string data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}

