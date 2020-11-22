using Microsoft.EntityFrameworkCore;
using ResultsDbContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResultsDbContext
{
    public partial class FiveOursContext : DbContext
    {
        public FiveOursContext()
        {
        }

        public FiveOursContext(DbContextOptions<FiveOursContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=FiveOurs;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
