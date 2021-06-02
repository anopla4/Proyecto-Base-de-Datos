using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SB_backend.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Models
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //DateBuilder
            //modelBuilder.Entity<Date>()
            //    .HasKey(c => new { c.Day, c.Hour });
            //PlayerBuilder
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerPosition>()
                .HasKey(c => new { c.PlayerId, c.PositionId});
            modelBuilder.Entity<PlayerPosition>()
               .HasData(new PlayerPosition { PlayerId = new Guid("488af061-69e1-42bf-91ee-603271758d8c"), PositionId = new Guid("bdcd2534-1ba3-4bd0-9099-13c6a0a9de41") },
               new PlayerPosition { PlayerId = new Guid("714420d1-2804-47f8-aaf1-79a522623274"), PositionId = new Guid("bdcd2534-1ba3-4bd0-9099-13c6a0a9de41") });
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
            modelBuilder.Entity<Serie>()
                .HasData(
                new Serie { Id = new Guid("6e6343fd-530b-4140-9607-727828a774c4"), CaracterId = new Guid("274f1ee4-3564-4b9c-8f9c-75bbfc20d4fc"), InitDate = new DateTime(2020, 9, 12), EndDate = new DateTime(2021, 4, 4), WinerId = new Guid("58cad299-e5e7-419b-93d7-154d084b2543"), LoserId = new Guid("86894ece-e6ad-4135-b45b-000ca20bc242"), NumberOfTeams = 16, NumberOfGames = 90, Name = "60 Serie Nacional" },
                new Serie { Id = new Guid("6a6345fd-431b-2120-9527-72782abf84c4"), CaracterId = new Guid("274f1ee4-3564-4b9c-8f9c-75bbfc20d4fc"), InitDate = new DateTime(2019, 8, 10), EndDate = new DateTime(2020, 1, 18), WinerId = new Guid("5d503b90-135b-4fe9-bb6f-70fd85d422e1"), LoserId = new Guid("86894ece-e6ad-4135-b45b-000ca20bc242"), NumberOfTeams = 16, NumberOfGames = 90, Name = "59 Serie Nacional" }
            );
            //PositionPlayerBuilder
            //modelBuilder.Entity<PositionPlayer>()
            //    .HasKey(c => new { c.PlayerId, c.PositionId });
            //TeamSerieBuilder
            modelBuilder.Entity<TeamSerie>()
                .HasKey(c => new { c.TeamId, c.SerieId, c.SerieInitDate, c.SerieEndDate });
            modelBuilder.Entity<TeamSerie>()
                .HasData(new TeamSerie { TeamId = new Guid("5d503b90-135b-4fe9-bb6f-70fd85d422e1"), SerieId = new Guid("6e6343fd-530b-4140-9607-727828a774c4"), SerieInitDate = new DateTime(2020, 9, 12), SerieEndDate = new DateTime(2021, 4, 4), FinalPosition = 2, WonGames = 44, LostGames = 31 },
                new TeamSerie { TeamId = new Guid("1c6f9b78-d8d2-4ba8-909f-6db4629f1f08"), SerieId = new Guid("6e6343fd-530b-4140-9607-727828a774c4"), SerieInitDate = new DateTime(2020, 9, 12), SerieEndDate = new DateTime(2021, 4, 4), FinalPosition = 9, WonGames = 41, LostGames = 34 });
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
            modelBuilder.Entity<TeamSeriePlayer>()
               .HasData(new TeamSeriePlayer { PlayerId = new Guid("488af061-69e1-42bf-91ee-603271758d8c"), TeamId = new Guid("5d503b90-135b-4fe9-bb6f-70fd85d422e1"), SerieId = new Guid("6e6343fd-530b-4140-9607-727828a774c4"), SerieInitDate = new DateTime(2020, 9, 12), SerieEndDate = new DateTime(2021, 4, 4) },
               new TeamSeriePlayer { PlayerId = new Guid("714420d1-2804-47f8-aaf1-79a522623274"), TeamId = new Guid("1c6f9b78-d8d2-4ba8-909f-6db4629f1f08"), SerieId = new Guid("6e6343fd-530b-4140-9607-727828a774c4"), SerieInitDate = new DateTime(2020, 9, 12), SerieEndDate = new DateTime(2021, 4, 4) });
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
            modelBuilder.Entity<Position>().HasData(new Position { Id = new Guid("57cbcda7-cbac-42b5-bc0e-c71eb8540e27"), PositionName = "C" }, new Position { Id = new Guid("a8660d61-d848-4a78-a41a-ea9c35d3f033"), PositionName = "1B" }, new Position { Id = new Guid("ca2cc279-8a1d-49d2-bdc0-61c2c553e216"), PositionName = "2B" }, new Position { Id = new Guid("f46b6571-8827-4736-b19f-d642fb7bf908"), PositionName = "3B" }, new Position { Id = new Guid("8e66be38-216d-4874-a8d1-26465e853000"), PositionName = "SS" }, new Position { Id = new Guid("bdcd2534-1ba3-4bd0-9099-13c6a0a9de41"), PositionName = "P" }, new Position { Id = new Guid("0156a2e6-b9fe-43d8-9f68-012251df9e92"), PositionName = "LF" }, new Position { Id = new Guid("04a2cadc-4608-4a96-8f55-b4ceb793f51b"), PositionName = "RF" }, new Position { Id = new Guid("c548fdc4-de7f-43c4-97fb-131e8234958b"), PositionName = "CF" }, new Position { Id = new Guid("13505c5f-d380-4cd0-9d58-fca642491f81"), PositionName = "BD" });
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
            modelBuilder.Entity<Game>()
                .HasData(new Game { GameId = new Guid("9c9cdf30-6ea5-4f95-a736-273052cdf3a4"), GameDate = new DateTime(2020, 9, 12), GameTime = "14:00", LoserTeamId = new Guid("1c6f9b78-d8d2-4ba8-909f-6db4629f1f08"), WinerTeamId = new Guid("5d503b90-135b-4fe9-bb6f-70fd85d422e1"), SerieId = new Guid("6e6343fd-530b-4140-9607-727828a774c4"), SerieInitDate = new DateTime(2020, 9, 12), SerieEndDate = new DateTime(2021, 4, 4), PitcherWinerId = new Guid("488af061-69e1-42bf-91ee-603271758d8c"), PitcherLoserId = new Guid("714420d1-2804-47f8-aaf1-79a522623274"), InFavorCarrers = 15, AgainstCarrers = 8 });
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
            //ModelBuilderTeam
            modelBuilder.Entity<Team>()
                .HasData(new Team { Id = new Guid("8b0cdf30-6ea5-4f95-a736-273052cdf3a1"), Name = "Artemisa", Color = "rojo", Initials = "ART" }, new Team { Id = new Guid("185adf42-a57e-4ec8-8e22-25f62aa85a17"), Name = "Pinar del Río", Color = "verde", Initials = "PRI" }, new Team { Id = new Guid("6a472570-f244-4828-acc4-53bf7f862712"), Name = "Mayabeque", Color = "rojo", Initials = "MAY" },
                new Team { Id = new Guid("b6e6b08c-9b2b-45eb-978b-c22d1f06142f"), Name = "Industriales", Color = "azul", Initials = "IND" }, new Team { Id = new Guid("5d503b90-135b-4fe9-bb6f-70fd85d422e1"), Name = "Matanzas", Color = "rojo,amarillo", Initials = "MTZ" }, new Team { Id = new Guid("a6da048a-7794-44de-8c55-0b0fc599d1cb"), Name = "Cienfuegos", Color = "verde,gris", Initials = "CFG" },
                new Team { Id = new Guid("0b8257f3-4916-42a1-93bc-d3cab4013318"), Name = "Isla dela Juventud", Color = "azul,blanco", Initials = "IJV" }, new Team { Id = new Guid("75e36e7e-6b97-4044-bfc4-437e193d074f"), Name = "Villa Clara", Color = "naranja", Initials = "VCL" }, new Team { Id = new Guid("ce405e0a-91a7-417f-9da4-74b0b75acc3c"), Name = "SanctiSpiritus", Color = "azul,naranja", Initials = "SSP" },
                new Team { Id = new Guid("0c9f56f4-2634-42ae-a762-dad72ffff441"), Name = "Ciego de Ávila", Color = "azul,rojo", Initials = "CAV" }, new Team { Id = new Guid("1c6f9b78-d8d2-4ba8-909f-6db4629f1f08"), Name = "Camagüey", Color = "azul,rojo", Initials = "CMG" }, new Team { Id = new Guid("58cad299-e5e7-419b-93d7-154d084b2543"), Name = "Granma", Color = "azul,rojo", Initials = "GRM" },
                new Team { Id = new Guid("6c489cf8-0c95-4d6d-8046-37f3f3e47621"), Name = "Holguín", Color = "azul,blanco", Initials = "HLG" }, new Team { Id = new Guid("88dc4e79-8f31-410c-b724-982a3abb68f1"), Name = "Santiago de Cuba", Color = "rojo", Initials = "SCU" }, new Team { Id = new Guid("86894ece-e6ad-4135-b45b-000ca20bc242"), Name = "Guantanamo", Color = "rojo", Initials = "GTM" });
            //ModelBuilderPlayer
            modelBuilder.Entity<Player>()
                .HasData(new Player { Id = new Guid("492ce38b-3d50-4ad1-b62f-04bbbe8b9f19"), Name = "Frank Madan Montejo", Age = 29, Year_Experience = 12 }, new Player { Id = new Guid("7c1eed91-70ea-4e1d-8d04-8ce6bb1f832b"), Name = "Luis Fonseca Garcia", Age = 19, Year_Experience = 2 }, new Player { Id = new Guid("dc37be22-bb87-4dee-9d22-e1dd80639ebc"), Name = "Yudier Rodriguez Leon", Age = 37, Year_Experience = 13 },
                new Player { Id = new Guid("205e50cc-6792-4d42-a09f-1a6f7925723f"), Name = "Yoen Socarras Suarez", Age = 34, Year_Experience = 15 }, new Player { Id = new Guid("009797dc-f53f-45c3-bba9-bb16951f0691"), Name = "Yankiel Mauri Gutierrez", Age = 24, Year_Experience = 6 }, new Player { Id = new Guid("60e597ae-52d5-4bcb-ad70-5108c9f4152c"), Name = "Alberto Bicet Labrada", Age = 35, Year_Experience = 15 },
                new Player { Id = new Guid("d7b43556-3ab5-4912-b197-6bcaf52f445c"), Name = "Adriel Echavarria Sanchez", Age = 26, Year_Experience = 7 }, new Player { Id = new Guid("f1e68897-9783-48d7-b9df-b1638ec2c480"), Name = "Leonardo Montero Alfonso", Age = 21, Year_Experience = 1 }, new Player { Id = new Guid("b222b771-1c84-46e0-9651-1c0edb1ed8e0"), Name = "Yoan Moreno Rodriguez", Age = 27, Year_Experience = 7 },
                new Player { Id = new Guid("fa073b24-5a15-4f46-ae88-ff75df54fbea"), Name = "Osvaldo Vazquez Torres", Age = 31, Year_Experience = 12 }, new Player { Id = new Guid("f7c39bc3-ca0b-4a2a-a851-210f3061810b"), Name = "Yordanis Samon Matamoros", Age = 39, Year_Experience = 18 }, new Player { Id = new Guid("0ca7d240-608c-46c0-ae3b-560441996ce0"), Name = "Miguel Antonio Gonzalez Puentes", Age = 22, Year_Experience = 1 },
                new Player { Id = new Guid("d8e175e8-caf8-4a0f-995d-bd28ab2287d1"), Name = "Yosvani Alarcon Tardio", Age = 36, Year_Experience = 16 }, new Player { Id = new Guid("6c84051a-5390-4e68-b3d1-adcae4d053c6"), Name = "Rafael Viñales Alvarez", Age = 29, Year_Experience = 10 }, new Player { Id = new Guid("e5bbc503-cf80-4348-a63a-b47a38c0adee"), Name = "Cesar Prieto Echevarria", Age = 22, Year_Experience = 4 },
                new Player { Id = new Guid("80d98e21-f989-4db7-b4f0-9f84088a9424"), Name = "Yasniel Gonzalez Vega", Age = 31, Year_Experience = 11 }, new Player { Id = new Guid("b0b73904-816d-4ec8-957a-e1c479dd0a44"), Name = "Geyser Cepeda Lima", Age = 24, Year_Experience = 4 }, new Player { Id = new Guid("c71dbf8a-a499-4753-8177-8bb613fa77f2"), Name = "Dennis Laza Spencer", Age = 37, Year_Experience = 12 },
                new Player { Id = new Guid("49ca16f2-ab20-478e-a09d-47371337c577"), Name = "Frederich Cepeda Cruz", Age = 41, Year_Experience = 24 }, new Player { Id = new Guid("488af061-69e1-42bf-91ee-603271758d8c"), Name = "Yosimar Cousin De La Rosa", Age = 23, Year_Experience = 6 }, new Player { Id = new Guid("50ceec15-5eed-4dee-8903-ad7b8b9436a4"), Name = "Rodolfo Soris Yera", Age = 33, Year_Experience = 12 },
                new Player { Id = new Guid("4536f820-d112-448e-8a52-cb4134e2f824"), Name = "Ruben Rodriguez Fonseca", Age = 26, Year_Experience = 4 }, new Player { Id = new Guid("96638775-f065-4dfb-91e9-5e5f66437c11"), Name = "Yoidel Castaneda Donny", Age = 24, Year_Experience = 3 }, new Player { Id = new Guid("84930b33-5018-4357-94ce-a3a6de2ea301"), Name = "Luis Angel Gomez Gamez", Age = 36, Year_Experience = 15 },
                new Player { Id = new Guid("e53c8e44-4792-4b8c-aa57-b04e961abefb"), Name = "Carlos Enrique Vera Barreda", Age = 24, Year_Experience = 3 }, new Player { Id = new Guid("714420d1-2804-47f8-aaf1-79a522623274"), Name = "Noelvis Entenza Gonzalez", Age = 35, Year_Experience = 4 }, new Player { Id = new Guid("3b925682-371c-4d5b-ae8a-c5aef7ee0d17"), Name = "Yaniel Blanco Portal", Age = 30, Year_Experience = 9 });
            //ModelBuilderDirector
            modelBuilder.Entity<Director>()
                .HasData(new Director { Id = new Guid("9aeff7f0-6843-4637-b8d8-fced1a49d32b"), Name = "Manuel Vigoa Amore" }, new Director { Id = new Guid("1a2fa462-a320-43dd-9903-41177f50f8dd"), Name = "Guillermo Rolando Carmona Casanova" }, new Director { Id = new Guid("e6d4c869-7fa4-4eb2-8d4d-f5eb6567e5a7"), Name = "Yorelvis Charles Martinez" },
                new Director { Id = new Guid("534abec3-505b-4525-b94c-68e3bdb0390a"), Name = "Pablo Alberto Civil Espinosa" }, new Director { Id = new Guid("c4ad1b19-e3c4-4bf0-a3a2-2cd75800a4b6"), Name = "Alain Alvarez Moya" }, new Director { Id = new Guid("31c778f7-e1c6-44c4-ba5c-bb6f37acb64b"), Name = "Michael Gonazalez Ventura" },
                new Director { Id = new Guid("84e072e7-11b9-48db-9d14-5d18df733e24"), Name = "Miguel Borroto Gonzales" }, new Director { Id = new Guid("6e6343ad-530a-4140-9607-72782aae74c4"), Name = "Armando Jesus Ferrer Ruiz" }, new Director { Id = new Guid("66e76481-6af7-440b-9321-4c274d21f54c"), Name = "Carlos Manuel Marti Santos" },
                new Director { Id = new Guid("c732f890-05c8-42f8-9cad-1e46d52ff6ec"), Name = "Alexander Urquiola Hernandez" }, new Director { Id = new Guid("bc35b109-4b68-46c4-b83a-ac26d2734b7c"), Name = "Agustin Lescaille Lopez" }, new Director { Id = new Guid("5abc5ecc-e439-434c-af9b-c791d051fb8c"), Name = "Eriberto Rosales Hernandez" },
                new Director { Id = new Guid("cd118d72-8543-42aa-ad6c-5df2a39a9e62"), Name = "Fransisco Martinez Sanchez" }, new Director { Id = new Guid("c68c20a4-80e6-4a26-8420-32d0f023ffa1"), Name = "Eriel Sanchez Leon" }, new Director { Id = new Guid("a47471c0-2c48-4956-a6f0-0193752eb0be"), Name = "Jose Luis Rodriguez Pantoja" },
                new Director { Id = new Guid("d7ea6570-a782-4236-bf39-4f852e2ffc34"), Name = "Jose Antonio Garcia Uña" });
            //ModelBuilderCaraccter
            modelBuilder.Entity<Caracter>()
                .HasData(new Caracter { Id = new Guid("274f1ee4-3564-4b9c-8f9c-75bbfc20d4fc"), Caracter_Name = "Nacional" });
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
