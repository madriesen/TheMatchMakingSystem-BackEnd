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
        public DbSet<UserWedstrijd> UserWedstrijden { get; set; }
        public DbSet<TableWedstrijd> TableWedstrijden { get; set; }
        public DbSet<WedstrijdType> WedstrijdTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Table>().ToTable("Table");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Wedstrijd>().ToTable("Wedstrijd");
            modelBuilder.Entity<UserWedstrijd>().ToTable("UserWedstrijd");
            modelBuilder.Entity<TableWedstrijd>().ToTable("TableWedstrijd");
            modelBuilder.Entity<WedstrijdType>().ToTable("WedstrijdType");
        }
    }
}
