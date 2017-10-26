﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMovies.Entities
{
    public class Rental:IEntityBase
    {
        public int ID { get; set; }
        public int CustomeId { get; set; }
        public int StockId { get; set; }
        public virtual Stock Stock { get; set; } 
        public DateTime RentalDate { get; set; }
        public Nullable<DateTime> ReturnedDate { get; set; }
        public string Status { get; set; }
    }
}
