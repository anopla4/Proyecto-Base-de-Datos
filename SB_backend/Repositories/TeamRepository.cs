﻿using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SB_backend.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private AppDBContext _teamContext;
        public TeamRepository(AppDBContext teamContext)
        {
            _teamContext = teamContext;
        }
        public Team AddTeam(Team team)
        {
            team.Id = Guid.NewGuid();
            _teamContext.Teams.Add(team);
            _teamContext.SaveChanges();
            return team;
        }

        public List<Team> getTeams()
        {
            return _teamContext.Teams.ToList();
        }
        public Team getTeam(Guid Id)
        {
            var team = _teamContext.Teams.Find(Id);
            if (team == null)
                throw new KeyNotFoundException("No se encuentra el equipo especificado");
            return team;
        }

        public bool RemoveTeam(Team team)
        {
            var curr_team = _teamContext.Teams.Find(team.Id);

            if (curr_team != null)
            {
                foreach (var teamSerie in _teamContext.TeamsSeries.Where(x => x.TeamId == curr_team.Id))
                    _teamContext.TeamsSeries.Remove(teamSerie);
                foreach (var serie in _teamContext.Series.Where(x => x.WinerId == curr_team.Id || x.LoserId == curr_team.Id))
                {
                    if (serie.WinerId == curr_team.Id) serie.WinerId = null;
                    if (serie.LoserId== curr_team.Id) serie.LoserId = null;
                    _teamContext.Series.Update(serie);
                }
                foreach (var change in _teamContext.PlayersChangesGames.Include(c => c.Game).Where(x => x.Game.WinerTeamId == curr_team.Id || x.Game.LoserTeamId == curr_team.Id))
                    _teamContext.PlayersChangesGames.Remove(change);
                foreach (var playerGame in _teamContext.PlayersGames.Include(c => c.Game).Where(x => x.Game.WinerTeamId == curr_team.Id || x.Game.LoserTeamId == curr_team.Id))
                    _teamContext.PlayersGames.Remove(playerGame);
                foreach (var game in _teamContext.Games.Where(x => x.WinerTeamId == curr_team.Id || x.LoserTeamId == curr_team.Id))
                    _teamContext.Games.Remove(game);
                foreach (var tsp in _teamContext.TeamsSeriesPlayers.Where(x => x.TeamId == curr_team.Id))
                    _teamContext.TeamsSeriesPlayers.Remove(tsp);
                foreach (var tsd in _teamContext.TeamsSeriesDirectors.Where(x => x.TeamSerieId == curr_team.Id))
                    _teamContext.TeamsSeriesDirectors.Remove(tsd);
                foreach (var player in _teamContext.Players.Where(x => x.Current_TeamId == curr_team.Id))
                {
                    player.Current_TeamId = null;
                    _teamContext.Players.Update(player);
                }
                _teamContext.Teams.Remove(curr_team);
                _teamContext.SaveChanges();
                return true;
            }
            throw new KeyNotFoundException("No se encuentra el equipo especificado");
        }

        public Team UpdateTeam(Team team)
        {
            var curr_team = _teamContext.Teams.Find(team.Id);

            if (curr_team != null)
            {
                curr_team.Color = team.Color;
                curr_team.Initials = team.Initials;
                curr_team.Name = team.Name;
                if(team.ImgPath != null)
                    curr_team.ImgPath = team.ImgPath;
                _teamContext.Teams.Update(curr_team);
                _teamContext.SaveChanges();
            }
            throw new KeyNotFoundException("No se encuentra el equipo especificado");
        }
    }
}
