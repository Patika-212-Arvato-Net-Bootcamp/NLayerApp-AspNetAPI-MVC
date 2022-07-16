using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
   public class Genres : BaseEntity
    {

        public string Name { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
