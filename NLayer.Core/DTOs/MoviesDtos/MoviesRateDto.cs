using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.MoviesDtos
{
    public class MoviesRateDto : BaseDto
    {
        public string title { get; set; }
        public string overview { get; set; }
        public int vote_count { get; set; }
        public string vote_average { get; set; }



    }
}
