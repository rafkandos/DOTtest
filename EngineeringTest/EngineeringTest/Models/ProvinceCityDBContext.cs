using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngineeringTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineeringTest.Models
{
    public class ProvinceCityDBContext : DbContext
    {
        public ProvinceCityDBContext (DbContextOptions<ProvinceCityDBContext> options) : base(options)
        {

        }

        public DbSet<Province> Province { get; set; }
        public DbSet<City> City { get; set; }
    }
}
