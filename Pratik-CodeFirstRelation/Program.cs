using Microsoft.EntityFrameworkCore;
using Pratik_CodeFirstRelation.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Pratik_CodeFirstRelation.Data
{
    public class PatikaSecondDbContext : DbContext
    {
        public PatikaSecondDbContext(DbContextOptions<PatikaSecondDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-MQI8H1N\SQLEXPRESS;Database=PatikaCodeFirstDb2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                        .HasOne(p => p.User)
                        .WithMany(u => u.Posts)
                        .HasForeignKey(p => p.UserId);
        }
    }
}
