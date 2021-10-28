using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktivWebb.Models.Dtos.Omdb
{
    public class OmdbMovieDto
    {
        public string Title { get; set; }
        public string imdbId { get; set; }
        public string plot { get; set; }
        public string genre { get; set; }
        public string year { get; set; }
        public string director { get; set; }
        public string actors { get; set; }
        public string awards { get; set; }
        public string runtime { get; set; }
        public string poster { get; set; }
        public string released { get; set; }
        public string imdbVotes { get; set; }
        public string boxOffice { get; set; }
        public List<RatingSourceDto> ratings { get; set; }
    }
}
