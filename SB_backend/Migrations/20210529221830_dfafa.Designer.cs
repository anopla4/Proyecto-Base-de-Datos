﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SB_backend.Models;

namespace SB_backend.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210529221830_dfafa")]
    partial class dfafa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SB_backend.Models.Caracter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caracter_Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Caracters");
                });

            modelBuilder.Entity("SB_backend.Models.Date", b =>
                {
                    b.Property<string>("Day");

                    b.Property<string>("Hour");

                    b.HasKey("Day", "Hour");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("SB_backend.Models.Director", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("SB_backend.Models.Game", b =>
                {
                    b.Property<Guid>("GameId");

                    b.Property<Guid>("WinerTeamId");

                    b.Property<Guid>("LoserTeamId");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("GameTime")
                        .HasColumnType("time");

                    b.Property<Guid>("SerieId");

                    b.Property<DateTime>("SerieInitDate");

                    b.Property<DateTime>("SerieEndDate");

                    b.Property<int>("AgaintsCarrers");

                    b.Property<int>("InFavorCarrers");

                    b.Property<Guid>("PitcherLoserPlayerId");

                    b.Property<Guid>("PitcherLoserPositionId");

                    b.Property<Guid>("PitcherWinerPlayerId");

                    b.Property<Guid>("PitcherWinerPositionId");

                    b.HasKey("GameId", "WinerTeamId", "LoserTeamId", "GameDate", "GameTime", "SerieId", "SerieInitDate", "SerieEndDate");

                    b.HasIndex("LoserTeamId");

                    b.HasIndex("WinerTeamId");

                    b.HasIndex("PitcherLoserPlayerId", "PitcherLoserPositionId");

                    b.HasIndex("PitcherWinerPlayerId", "PitcherWinerPositionId");

                    b.HasIndex("SerieId", "SerieInitDate", "SerieEndDate");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("SB_backend.Models.PitcherChangeGame", b =>
                {
                    b.Property<TimeSpan>("GameTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("date");

                    b.Property<Guid>("SerieId");

                    b.Property<DateTime>("SerieInitDate");

                    b.Property<DateTime>("SerieEndDate");

                    b.Property<Guid>("PitcherInPlayerId");

                    b.Property<Guid>("PitcherInPositionId");

                    b.Property<Guid>("LoserTeamId");

                    b.Property<Guid>("PitcherOutPlayerId");

                    b.Property<Guid>("PitcherOutPositionId");

                    b.Property<Guid>("WinerTeamId");

                    b.HasKey("GameTime", "GameDate", "SerieId", "SerieInitDate", "SerieEndDate", "PitcherInPlayerId", "PitcherInPositionId");

                    b.HasIndex("LoserTeamId");

                    b.HasIndex("WinerTeamId");

                    b.HasIndex("PitcherInPlayerId", "PitcherInPositionId");

                    b.HasIndex("PitcherOutPlayerId", "PitcherOutPositionId");

                    b.HasIndex("SerieId", "SerieInitDate", "SerieEndDate");

                    b.ToTable("PitcherChangesGames");
                });

            modelBuilder.Entity("SB_backend.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<Guid>("Current_TeamId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Year_Experience");

                    b.HasKey("Id");

                    b.HasIndex("Current_TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SB_backend.Models.PlayerGame", b =>
                {
                    b.Property<Guid>("gameGameId");

                    b.Property<Guid>("PositionPlayerPlayerId");

                    b.Property<Guid>("PositionPlayerPositionId");

                    b.Property<DateTime>("gameGameDate")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("gameGameTime")
                        .HasColumnType("time");

                    b.Property<Guid>("gameLoserTeamId");

                    b.Property<DateTime>("gameSerieEndDate");

                    b.Property<Guid>("gameSerieId");

                    b.Property<DateTime>("gameSerieInitDate");

                    b.Property<Guid>("gameWinerTeamId");

                    b.HasKey("gameGameId", "PositionPlayerPlayerId", "PositionPlayerPositionId");

                    b.HasIndex("PositionPlayerPlayerId", "PositionPlayerPositionId");

                    b.HasIndex("gameGameId", "gameWinerTeamId", "gameLoserTeamId", "gameGameDate", "gameGameTime", "gameSerieId", "gameSerieInitDate", "gameSerieEndDate");

                    b.ToTable("PlayersGames");
                });

            modelBuilder.Entity("SB_backend.Models.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PositionName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Positions");

                    b.HasData(
                        new { Id = new Guid("6cfa519e-dc6a-42c5-96a0-8b48aa58b84e"), PositionName = "C" },
                        new { Id = new Guid("3b05a7c8-f0b5-4006-a447-ec080eeee51d"), PositionName = "1B" },
                        new { Id = new Guid("27ff8b46-e00b-47a4-bd1e-989c7896fb9e"), PositionName = "2B" },
                        new { Id = new Guid("1c1ed8c3-d023-4bca-9ae4-b5d3efda30d9"), PositionName = "3B" },
                        new { Id = new Guid("bdbcc356-36e3-4b57-9a5f-405cec9c475a"), PositionName = "SS" },
                        new { Id = new Guid("9d3c268e-d2c6-41a3-839d-bfc0e7ebb6b7"), PositionName = "P" },
                        new { Id = new Guid("fddc8276-76ad-4dd2-89cc-dfe20a2dcdf7"), PositionName = "LF" },
                        new { Id = new Guid("f6c693ca-9af3-4464-9549-61452dc5cb66"), PositionName = "RF" },
                        new { Id = new Guid("597fe1a4-236f-4c8a-b1d2-3f6d0bb21be9"), PositionName = "CF" },
                        new { Id = new Guid("7209556c-1887-465a-a7e4-5ec6d8eddf50"), PositionName = "BD" }
                    );
                });

            modelBuilder.Entity("SB_backend.Models.PositionPlayer", b =>
                {
                    b.Property<Guid>("PlayerId");

                    b.Property<Guid>("PositionId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Position_Average");

                    b.HasKey("PlayerId", "PositionId");

                    b.HasIndex("PositionId");

                    b.ToTable("PositionPlayers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PositionPlayer");
                });

            modelBuilder.Entity("SB_backend.Models.Serie", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTime>("InitDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<Guid>("CaracterId");

                    b.Property<Guid>("LoserId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("NumberOfGames");

                    b.Property<Guid>("WinerId");

                    b.HasKey("Id", "InitDate", "EndDate");

                    b.HasIndex("CaracterId");

                    b.HasIndex("LoserId");

                    b.HasIndex("WinerId");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("SB_backend.Models.StartPositionPlayerSerie", b =>
                {
                    b.Property<Guid>("PositionId");

                    b.Property<Guid>("SerieId");

                    b.Property<DateTime>("SerieInitDate");

                    b.Property<DateTime>("SerieEndDate");

                    b.Property<Guid>("PlayerId");

                    b.HasKey("PositionId", "SerieId", "SerieInitDate", "SerieEndDate");

                    b.HasIndex("PlayerId", "PositionId");

                    b.HasIndex("SerieId", "SerieInitDate", "SerieEndDate");

                    b.ToTable("StartPositionPlayersSeries");
                });

            modelBuilder.Entity("SB_backend.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<string>("Initials")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SB_backend.Models.TeamSerie", b =>
                {
                    b.Property<Guid>("TeamId");

                    b.Property<Guid>("SerieId");

                    b.Property<DateTime>("SerieInitDate");

                    b.Property<DateTime>("SerieEndDate");

                    b.Property<int>("FinalPosition");

                    b.Property<int>("LostGames");

                    b.Property<int>("WonGames");

                    b.HasKey("TeamId", "SerieId", "SerieInitDate", "SerieEndDate");

                    b.HasIndex("SerieId", "SerieInitDate", "SerieEndDate");

                    b.ToTable("TeamsSeries");
                });

            modelBuilder.Entity("SB_backend.Models.TeamSerieDirector", b =>
                {
                    b.Property<Guid>("DirectorId");

                    b.Property<Guid>("SerieId");

                    b.Property<DateTime>("SerieInitDate");

                    b.Property<DateTime>("SerieEndDate");

                    b.Property<Guid>("TeamSerieId");

                    b.HasKey("DirectorId", "SerieId", "SerieInitDate", "SerieEndDate");

                    b.HasIndex("TeamSerieId");

                    b.HasIndex("SerieId", "SerieInitDate", "SerieEndDate");

                    b.ToTable("TeamsSeriesDirectors");
                });

            modelBuilder.Entity("SB_backend.Models.TeamSeriePlayer", b =>
                {
                    b.Property<Guid>("PlayerId");

                    b.Property<Guid>("SerieId");

                    b.Property<DateTime>("SerieInitDate");

                    b.Property<DateTime>("SerieEndDate");

                    b.Property<Guid>("TeamSerieId");

                    b.HasKey("PlayerId", "SerieId", "SerieInitDate", "SerieEndDate");

                    b.HasIndex("TeamSerieId");

                    b.HasIndex("SerieId", "SerieInitDate", "SerieEndDate");

                    b.ToTable("TeamsSeriesPlayers");
                });

            modelBuilder.Entity("SB_backend.Models.Pitcher", b =>
                {
                    b.HasBaseType("SB_backend.Models.PositionPlayer");

                    b.Property<double>("ERA");

                    b.Property<string>("Hand");

                    b.ToTable("Pitcher");

                    b.HasDiscriminator().HasValue("Pitcher");
                });

            modelBuilder.Entity("SB_backend.Models.Game", b =>
                {
                    b.HasOne("SB_backend.Models.Team", "LoserTeam")
                        .WithMany()
                        .HasForeignKey("LoserTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Team", "WinerTeam")
                        .WithMany()
                        .HasForeignKey("WinerTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Pitcher", "PitcherLoser")
                        .WithMany()
                        .HasForeignKey("PitcherLoserPlayerId", "PitcherLoserPositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Pitcher", "PitcherWiner")
                        .WithMany()
                        .HasForeignKey("PitcherWinerPlayerId", "PitcherWinerPositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Serie", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId", "SerieInitDate", "SerieEndDate")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SB_backend.Models.PitcherChangeGame", b =>
                {
                    b.HasOne("SB_backend.Models.Team", "LoserTeam")
                        .WithMany()
                        .HasForeignKey("LoserTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Team", "WinerTeam")
                        .WithMany()
                        .HasForeignKey("WinerTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Pitcher", "PitcherIn")
                        .WithMany()
                        .HasForeignKey("PitcherInPlayerId", "PitcherInPositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Pitcher", "PitcherOut")
                        .WithMany()
                        .HasForeignKey("PitcherOutPlayerId", "PitcherOutPositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Serie", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId", "SerieInitDate", "SerieEndDate")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SB_backend.Models.Player", b =>
                {
                    b.HasOne("SB_backend.Models.Team", "Current_Team")
                        .WithMany()
                        .HasForeignKey("Current_TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SB_backend.Models.PlayerGame", b =>
                {
                    b.HasOne("SB_backend.Models.PositionPlayer", "PositionPlayer")
                        .WithMany()
                        .HasForeignKey("PositionPlayerPlayerId", "PositionPlayerPositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Game", "game")
                        .WithMany()
                        .HasForeignKey("gameGameId", "gameWinerTeamId", "gameLoserTeamId", "gameGameDate", "gameGameTime", "gameSerieId", "gameSerieInitDate", "gameSerieEndDate")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SB_backend.Models.PositionPlayer", b =>
                {
                    b.HasOne("SB_backend.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SB_backend.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SB_backend.Models.Serie", b =>
                {
                    b.HasOne("SB_backend.Models.Caracter", "CaracterSerie")
                        .WithMany()
                        .HasForeignKey("CaracterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SB_backend.Models.Team", "Loser")
                        .WithMany()
                        .HasForeignKey("LoserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Team", "Winer")
                        .WithMany()
                        .HasForeignKey("WinerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SB_backend.Models.StartPositionPlayerSerie", b =>
                {
                    b.HasOne("SB_backend.Models.PositionPlayer", "PositionPlayer")
                        .WithMany()
                        .HasForeignKey("PlayerId", "PositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Serie", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId", "SerieInitDate", "SerieEndDate")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SB_backend.Models.TeamSerie", b =>
                {
                    b.HasOne("SB_backend.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SB_backend.Models.Serie", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId", "SerieInitDate", "SerieEndDate")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SB_backend.Models.TeamSerieDirector", b =>
                {
                    b.HasOne("SB_backend.Models.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SB_backend.Models.Team", "TeamSerie")
                        .WithMany()
                        .HasForeignKey("TeamSerieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SB_backend.Models.Serie", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId", "SerieInitDate", "SerieEndDate")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SB_backend.Models.TeamSeriePlayer", b =>
                {
                    b.HasOne("SB_backend.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SB_backend.Models.Team", "TeamSerie")
                        .WithMany()
                        .HasForeignKey("TeamSerieId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Serie", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId", "SerieInitDate", "SerieEndDate")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}