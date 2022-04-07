#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GBC.Models;

namespace GBC.Data
{
    public class GBCContext : DbContext
    {
        public GBCContext (DbContextOptions<GBCContext> options)
            : base(options)
        {
        }

        public DbSet<GBC.Models.TechManager> TechManager { get; set; }

        public DbSet<GBC.Models.CustomerManager> CustomerManager { get; set; }

        public DbSet<GBC.Models.IncidentPage> IncidentPage { get; set; }

        public DbSet<GBC.Models.ProductManager> ProductManager { get; set; }
    }
}
