using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMovies.Entities
{
    public class Genre:IEntityBase
    {
        public Genre()
        {
            
        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
