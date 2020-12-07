using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using FoosballAPI.Models;

namespace FoosballAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Wedstrijd> Wedstrijden { get; set; }
        public DbSet<WedstrijdType> WedstrijdTypes { get; set; }
        public DbSet<Tournooi> Tournooien { get; set; }
        public DbSet<Ploeg> Ploegen { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Table>().ToTable("Table");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Wedstrijd>().ToTable("Wedstrijd");
            modelBuilder.Entity<WedstrijdType>().ToTable("WedstrijdType");
            modelBuilder.Entity<Tournooi>().ToTable("Tournooi");
            modelBuilder.Entity<Ploeg>().ToTable("Ploeg");
        }
    }
}
