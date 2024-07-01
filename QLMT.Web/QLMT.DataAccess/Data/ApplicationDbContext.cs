using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLMT.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMT.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<NetworkRange> NetworkRanges { get; set; }
        public DbSet<LocationManagement> LocationManagements { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Management> Managements { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
