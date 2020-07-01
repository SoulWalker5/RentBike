using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BikeApi.Models
{
    public class BikeContext : DbContext
    {
        public BikeContext() : base("connectionString")
        {

        }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<BikeType> BikeTypes { get; set; }
        public DbSet<RentState> RentStates { get; set; }

    }
}