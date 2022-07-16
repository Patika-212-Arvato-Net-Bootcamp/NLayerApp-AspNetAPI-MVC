using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class User : BaseEntity
    {

        public string Name { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
    }
}
