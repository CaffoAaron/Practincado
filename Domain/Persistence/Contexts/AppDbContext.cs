using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Practincado.Domain.Models;

namespace Practincado.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Urgencie> Urgencies { get; set; }
        public DbSet<Guardian> Guardians { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Urgencie>().ToTable("Urgencies");
            builder.Entity<Urgencie>().HasKey(p => p.Id);
            builder.Entity<Urgencie>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Urgencie>().Property(p => p.Title).IsRequired();
            builder.Entity<Urgencie>().Property(p => p.Latitude).IsRequired();
            builder.Entity<Urgencie>().Property(p => p.Longitude).IsRequired();


            builder.Entity<Guardian>().ToTable("Guardians");
            builder.Entity<Guardian>().HasKey(p => p.Id);
            builder.Entity<Guardian>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Guardian>().Property(p => p.Username).IsRequired().HasMaxLength(30);
            builder.Entity<Guardian>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Guardian>().Property(p => p.FirstName).HasMaxLength(30);
            builder.Entity<Guardian>().Property(p => p.LastName).HasMaxLength(60);
            builder.Entity<Guardian>()
                .HasMany(p => p.Urgencies)
                .WithOne(p => p.Guardian)
                .HasForeignKey(p => p.GuardianId);
            builder.Entity<Guardian>().HasData
                (
                new Guardian { Id= 100, Username= "Caffo2020", Email="aaron@gmail.com", FirstName= "Aaron", LastName ="Alva" , Gender="Hombre", Address ="av.diametes 1414" },
                new Guardian { Id = 101, Username = "alison54", Email = "alison@gmail.com", FirstName = "Alison", LastName = "Sempertegui", Gender = "Mijer", Address = "av.tuñoque 717" }
                );



        }
    }
}
