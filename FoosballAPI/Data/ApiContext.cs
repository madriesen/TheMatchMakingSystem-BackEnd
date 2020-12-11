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
        public DbSet<Score> Scores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Tournooi>().ToTable("Tournooi");
            modelBuilder.Entity<WedstrijdType>().ToTable("WedstrijdType");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasOne(u=>u.Ploeg).WithMany(u=>u.Players);
            modelBuilder.Entity<User>().HasMany(u => u.Teams).WithOne(u => u.Player1);
            modelBuilder.Entity<Score>().ToTable("Score");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Team>().HasMany(u => u.Scores).WithOne(u => u.Winnaar);
            modelBuilder.Entity<Ploeg>().ToTable("Ploeg");
            modelBuilder.Entity<Table>().ToTable("Table");
            modelBuilder.Entity<Wedstrijd>().ToTable("Wedstrijd");
            modelBuilder.Entity<Wedstrijd>().HasMany(u => u.Scores).WithOne(u => u.Wedstrijd);




        }
    }
}
