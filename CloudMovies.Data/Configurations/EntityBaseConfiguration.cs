﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using CloudMovies.Entities;

namespace CloudMovies.Configurations
{
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T:class,IEntityBase
    {
        public EntityBaseConfiguration()
        {
            HasKey(e => e.ID);
        }
    }
}
