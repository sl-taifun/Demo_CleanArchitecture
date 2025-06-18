using DemoCleanArchitecture.Domain.Modeles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.Infrastructure.Database
{
    public class AppDbContext :DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Member> Member { get; set; }

        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
 
}
