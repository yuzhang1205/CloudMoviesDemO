﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMovies.Entities;

namespace CloudMovies.Configurations
{
    public class RoleConfiguration:EntityBaseConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(r=>r.Name).IsRequired().HasMaxLength(50);
        }
    }
}
