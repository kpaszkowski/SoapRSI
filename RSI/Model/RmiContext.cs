using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RSI.Model
{
    public class RmiContext : DbContext
    {
        public RmiContext() : base()
        {
        }
        public DbSet<Cow> Cows { get; set; }

        public static RmiContext Create()
        {
            return new RmiContext();
        }
    }
}