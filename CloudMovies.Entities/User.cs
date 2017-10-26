﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMovies.Entities
{
    public class User:IEntityBase
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
