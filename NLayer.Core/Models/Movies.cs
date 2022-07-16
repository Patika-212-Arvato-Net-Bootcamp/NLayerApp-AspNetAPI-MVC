using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Movies:BaseEntity
    {
   

        public string adult { get; set; }
        public string budget { get; set; }
        public string homepage { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string popularity { get; set; }
        public string poster_path { get; set; }
        public string production_companies { get; set; }
        public string production_countries { get; set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public double runtime { get; set; }
        public string spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public string video { get; set; }
        public string vote_average { get; set; }
        public int vote_count { get; set; }

        public int GenresId { get; set; }
        public Genres Genres { get; set; }
    }
}
