using System;
using FiveOursDAL.ConnectionString;
using FiveOursDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FiveOursDAL.Configurations
{
    public partial class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
        {
        }

        public virtual DbSet<Result> Results { get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = Connection.ReadConnectionString();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ResultConfiguration());
        }
    }
}