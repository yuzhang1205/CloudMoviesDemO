﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMovies.Entities
{
    public class Customer:IEntityBase
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string IdentityCard { get; set; } 
        public Guid UniqueKey { get; set; } 
        public DateTime DateOfBirth { get; set; } 
        public string Mobile { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}
