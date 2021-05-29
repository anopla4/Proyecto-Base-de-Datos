﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SB_backend.Models;

namespace SB_backend.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                    b.Property<TimeSpan>("GameTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("date");

                    b.Property<Guid>("SerieId");

                    b.Property<DateTime>("SerieInitDate");

                    b.Property<DateTime>("SerieEndDate");

                    b.Property<int>("AgaintsCarrers");

                    b.Property<int>("InFavorCarrers");

                    b.Property<Guid>("LoserTeamId");

                    b.Property<Guid>("PitcherLoserPlayerId");

                    b.Property<Guid>("PitcherLoserPositionId");

                    b.Property<Guid>("PitcherWinerPlayerId");

                    b.Property<Guid>("PitcherWinerPositionId");

                    b.Property<Guid>("WinerTeamId");

                    b.HasKey("GameTime", "GameDate", "SerieId", "SerieInitDate", "SerieEndDate");

                    b.HasIndex("LoserTeamId");

                    b.HasIndex("WinerTeamId");

                    b.HasIndex("PitcherLoserPlayerId", "PitcherLoserPositionId");

                    b.HasIndex("PitcherWinerPlayerId", "PitcherWinerPositionId");

                    b.HasIndex("SerieId", "SerieInitDate", "SerieEndDate");

                    b.ToTable("Games");
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
                    b.Property<TimeSpan>("GameTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("date");

                    b.Property<Guid>("SerieId");

                    b.Property<DateTime>("SerieInitDate");

                    b.Property<DateTime>("SerieEndDate");

                    b.Property<Guid>("PositionPlayerPlayerId");

                    b.Property<Guid>("PositionPlayerPositionId");

                    b.Property<Guid>("LoserTeamId");

                    b.Property<Guid>("WinerTeamId");

                    b.HasKey("GameTime", "GameDate", "SerieId", "SerieInitDate", "SerieEndDate", "PositionPlayerPlayerId", "PositionPlayerPositionId");

                    b.HasIndex("LoserTeamId");

                    b.HasIndex("WinerTeamId");

                    b.HasIndex("PositionPlayerPlayerId", "PositionPlayerPositionId");

                    b.HasIndex("SerieId", "SerieInitDate", "SerieEndDate");

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
                        new { Id = new Guid("5212e411-7cd7-494f-9c18-1af659dbcc78"), PositionName = "C" },
                        new { Id = new Guid("1c323e07-77d8-4043-bfbe-bbb92437dd03"), PositionName = "1B" },
                        new { Id = new Guid("d89c2e9c-3b71-4633-ad9f-ee7f7514a4d8"), PositionName = "2B" },
                        new { Id = new Guid("3a7e4c3b-a2a6-44ba-ac92-eef8cfc8d392"), PositionName = "3B" },
                        new { Id = new Guid("69627233-8b2a-42a2-b7d2-50591f4da2aa"), PositionName = "SS" },
                        new { Id = new Guid("b28992f5-b3ce-4d08-9507-4daa84f2335c"), PositionName = "P" },
                        new { Id = new Guid("def6c1b2-0bc0-4481-8578-70736cbe45b9"), PositionName = "LF" },
                        new { Id = new Guid("99c3259d-e432-484e-b5df-4f6663b5ec3f"), PositionName = "RF" },
                        new { Id = new Guid("5d8ec263-bab7-43ba-b75c-78d050236347"), PositionName = "CF" },
                        new { Id = new Guid("be46fca2-9d4a-4e77-865e-e4e3c732714f"), PositionName = "BD" }
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

                    b.Property<int>("LosserGames");

                    b.Property<int>("WinnerGames");

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

            modelBuilder.Entity("SB_backend.Models.Player", b =>
                {
                    b.HasOne("SB_backend.Models.Team", "Current_Team")
                        .WithMany()
                        .HasForeignKey("Current_TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SB_backend.Models.PlayerGame", b =>
                {
                    b.HasOne("SB_backend.Models.Team", "LoserTeam")
                        .WithMany()
                        .HasForeignKey("LoserTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Team", "WinerTeam")
                        .WithMany()
                        .HasForeignKey("WinerTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.PositionPlayer", "PositionPlayer")
                        .WithMany()
                        .HasForeignKey("PositionPlayerPlayerId", "PositionPlayerPositionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SB_backend.Models.Serie", "Serie")
                        .WithMany()
                        .HasForeignKey("SerieId", "SerieInitDate", "SerieEndDate")
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
