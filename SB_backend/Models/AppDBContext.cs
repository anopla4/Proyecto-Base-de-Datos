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
        {   //DateBuilder
            //modelBuilder.Entity<Date>()
            //    .HasKey(c => new { c.Day, c.Hour });
            //PlayerBuilder
           
            modelBuilder.Entity<PlayerPosition>()
                .HasKey(c => new { c.PlayerId, c.PositionId});
            modelBuilder.Entity<Player>()
                .HasOne(c => c.Current_Team)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            //SerieBuilder
            modelBuilder.Entity<Serie>()
                .HasKey(c => new { c.Id, c.InitDate, c.EndDate });
            modelBuilder.Entity<Serie>()
                .HasOne(c => c.Winer)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Serie>()
                .HasOne(c => c.Loser)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            //PositionPlayerBuilder
            //modelBuilder.Entity<PositionPlayer>()
            //    .HasKey(c => new { c.PlayerId, c.PositionId });
            //TeamSerieBuilder
            modelBuilder.Entity<TeamSerie>()
                .HasKey(c => new { c.TeamId, c.SerieId, c.SerieInitDate, c.SerieEndDate });
            //TeamSeriePlayerBuilder
            modelBuilder.Entity<TeamSeriePlayer>().HasKey(c => new { c.PlayerId, c.SerieId, c.SerieInitDate, c.SerieEndDate });
            modelBuilder.Entity<TeamSeriePlayer>()
                .HasOne(c => c.Team)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TeamSeriePlayer>()
                .HasOne(c => c.Player)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TeamSeriePlayer>()
                .HasOne(c => c.Serie)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            //StartPositionPlayerBuilder
            //modelBuilder.Entity<StartPositionPlayerSerie>().HasKey(c => new { c.PositionId, c.SerieId, c.SerieInitDate, c.SerieEndDate });
            //modelBuilder.Entity<StartPositionPlayerSerie>()
            //    .HasOne(c => c.PositionPlayer)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<StartPositionPlayerSerie>()
            //    .HasOne(c => c.Serie)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Restrict);
            //TeamSerieDirectorBuilder
            modelBuilder.Entity<TeamSerieDirector>().HasKey(c => new { c.DirectorId, c.SerieId, c.SerieInitDate, c.SerieEndDate });
            //PositionBuilder
            modelBuilder.Entity<Position>().HasData(new Position { Id = Guid.NewGuid(), PositionName = "C" }, new Position { Id = Guid.NewGuid(), PositionName = "1B" }, new Position { Id = Guid.NewGuid(), PositionName = "2B" }, new Position { Id = Guid.NewGuid(), PositionName = "3B" }, new Position { Id = Guid.NewGuid(), PositionName = "SS" }, new Position { Id = Guid.NewGuid(), PositionName = "P" }, new Position { Id = Guid.NewGuid(), PositionName = "LF" }, new Position { Id = Guid.NewGuid(), PositionName = "RF" }, new Position { Id = Guid.NewGuid(), PositionName = "CF" }, new Position { Id = Guid.NewGuid(), PositionName = "BD" });
            //GameBuilder
            modelBuilder.Entity<Game>()
                .HasOne(c => c.Serie)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Game>()
                .HasOne(c => c.PitcherWiner)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Game>()
                .HasOne(c => c.PitcherLoser)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Game>()
                .HasOne(c => c.WinerTeam)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Game>()
                .HasOne(c => c.LoserTeam)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            //PlayerGameBuilder
            modelBuilder.Entity<PlayerGame>().HasKey(c => new {c.GameId,c.PlayerId,c.PositionId});
            modelBuilder.Entity<PlayerGame>()
                .HasOne(c => c.Game)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PlayerGame>()
                .HasOne(c => c.Player)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            //PositionPlayerChangeGameBuilder
            modelBuilder.Entity<PlayerChangeGame>().HasKey(c => new { c.GameId, c.PlayerIdIn, c.PlayerIdOut});
            modelBuilder.Entity<PlayerChangeGame>()
                .HasOne(c => c.Game)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PlayerChangeGame>()
               .HasOne(c => c.PlayerPositionIn)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PlayerChangeGame>()
                .HasOne(c => c.PlayerPositionOut)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            //StartTeamBuilder
            modelBuilder.Entity<StarPositionPlayerSerie>().HasKey(c => new { c.SerieId, c.SerieInitDate, c.SerieEndDate, c.PositionId });
            modelBuilder.Entity<StarPositionPlayerSerie>()
                .HasOne(c => c.Serie)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StarPositionPlayerSerie>()
                .HasOne(c => c.Player)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Caracter> Caracters { get; set; }
        //public DbSet<Date> Dates { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerPosition> PlayerPosition { get; set; }
        public DbSet<TeamSerie> TeamsSeries { get; set; }
        public DbSet<TeamSeriePlayer> TeamsSeriesPlayers { get; set; }
        public DbSet<TeamSerieDirector> TeamsSeriesDirectors { get; set; }
        //public DbSet<Pitcher> Pitchers { get; set; }
        public DbSet<StarPositionPlayerSerie> StarPositionPlayersSeries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerGame> PlayersGames { get; set; }
        public DbSet<PlayerChangeGame> PlayersChangesGames { get; set; }
        //public DbSet<PitcherChangeGame> PitcherChangesGames { get; set; } 
    }
}
