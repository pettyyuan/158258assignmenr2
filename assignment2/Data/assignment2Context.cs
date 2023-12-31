﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace assignment2.Data
{
    public class assignment2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public assignment2Context() : base("name=assignment2Context")
        {
        }

        public System.Data.Entity.DbSet<assignment2.Models.local_dishes> local_dishes { get; set; }

        public System.Data.Entity.DbSet<assignment2.Models.Cuisines> Cuisines { get; set; }
    }
}
