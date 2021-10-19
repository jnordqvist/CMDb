using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interaktivWebb.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Plot { get; set; } = "";
        public string Poster { get; set; } = "";
        public string Genre { get; set; } = "";
        public List<(string, string)> Rating { get; set; } = new List<(string, string)>();
    }
}
