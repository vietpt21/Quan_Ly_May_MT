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
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Screen> Screens { get; set; }

    }
}
