using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleInfoRegistration.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleInfoRegistration.DAL.Data
{
    public class AppDbContext : DbContext
    {
       
       
      
        public AppDbContext(
       DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(x => x.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(x => x.PasswordSalt)
                   .IsRequired()
                   .HasMaxLength(500);

                entity.Property(x => x.CreatedDate)
                    .IsRequired();

                entity.HasIndex(x => x.Email)
                    .IsUnique();
            });
        }
    }
}
