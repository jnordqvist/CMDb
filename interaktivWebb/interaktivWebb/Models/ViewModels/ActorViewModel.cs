using interaktivWebb.Models.Dtos.Omdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktivWebb.Models.ViewModels
{
    public class ActorViewModel
    {
        public string Actor { get; }
        public List<OmdbMovieDto> filteredOmdbMovies { get; } = new List<OmdbMovieDto>();
        public List<MovieDto> filteredCmdbMovies { get; } = new List<MovieDto>();
        public ActorViewModel(List<OmdbMovieDto> omdbMovies, IEnumerable<MovieDto> cmdbMovies, string targetActor)
        {
            Actor = targetActor;
            foreach (var movie in omdbMovies)
            {
                if (movie.actors != null)
                {
                    var actorList = movie.actors.Split(", ").ToList();
                    foreach (var currentActor in actorList)
                    {
                        if (currentActor == targetActor)
                        {
                            filteredOmdbMovies.Add(movie);
                            filteredCmdbMovies.Add(cmdbMovies.Where(x => x.imdbID == movie.imdbId).FirstOrDefault());
                            break;
                        }
                    } 
                }
            }
        }
    }
}
