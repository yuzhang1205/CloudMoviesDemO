﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMovies.Entities;

namespace CloudMovies.Configurations
{
    public class CustomerConfiguration:EntityBaseConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            Property(c => c.LastName).IsRequired().HasMaxLength(100);
            Property(c => c.Email).IsRequired().HasMaxLength(200);
            Property(c => c.IdentityCard).IsRequired().HasMaxLength(50);
            Property(c => c.UniqueKey).IsRequired();
            Property(c => c.DateOfBirth).IsRequired();
            Property(c => c.Mobile).IsOptional().HasMaxLength(10);
            Property(c => c.RegistrationDate).IsRequired();
        }
    }
}
