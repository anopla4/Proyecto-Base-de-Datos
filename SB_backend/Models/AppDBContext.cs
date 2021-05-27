using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Date>()
                .HasKey(c => new { c.Day, c.Hour });
            modelBuilder.Entity<Serie>()
                .HasKey(c => new { c.Id, c.Init_Date,c.End_Date });
            modelBuilder.Entity<PositionPlayer>()
                .HasKey(c => new { c.PlayerId, c.PositionId});
            modelBuilder.Entity<Position>().HasData(new Position { Id = Guid.NewGuid(),Position_Name = "C" }, new Position { Id = Guid.NewGuid(), Position_Name = "1B" }, new Position { Id = Guid.NewGuid(),Position_Name = "2B" }, new Position { Id = Guid.NewGuid(), Position_Name = "3B" }, new Position { Id = Guid.NewGuid(), Position_Name = "SS" }, new Position { Id = Guid.NewGuid(), Position_Name = "Lanzador" }, new Position { Id = Guid.NewGuid(), Position_Name = "LF" }, new Position { Id = Guid.NewGuid(), Position_Name = "RF" }, new Position { Id = Guid.NewGuid(), Position_Name = "CF" }, new Position { Id = Guid.NewGuid(), Position_Name = "BD" });
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Caracter> Caracters { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionPlayer> PositionPlayers { get; set; }
    }
}
