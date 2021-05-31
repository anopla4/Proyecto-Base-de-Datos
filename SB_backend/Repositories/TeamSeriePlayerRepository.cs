using Microsoft.EntityFrameworkCore;
using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class TeamSeriePlayerRepository : ITeamSeriePlayerRepository
    {
        private AppDBContext _context;
        public TeamSeriePlayerRepository(AppDBContext context)
        {
            _context = context;
        }
        public TeamSeriePlayer AddTeamSeriePlayer(TeamSeriePlayer teamSeriePlayer)
        {
            Team team = _context.Teams.Find(teamSeriePlayer.TeamSerieId);
            if (team == null)
                return null;
            Serie serie = _context.Series.Find(teamSeriePlayer.SerieId, teamSeriePlayer.SerieInitDate, teamSeriePlayer.SerieEndDate);
            if (serie == null)
                return null;
            bool player = _context.Players.Any(c => c.Id == teamSeriePlayer.PlayerId && c.PositionId == teamSeriePlayer.PlayerPositionId);
            if (!player)
                return null;
            _context.TeamsSeriesPlayers.Add(teamSeriePlayer);
            _context.SaveChanges();
            return teamSeriePlayer;
        }

        public List<Player> GetPlayersInSerie(Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate)
        {
            bool flag = _context.TeamsSeriesPlayers.Any(c => c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate ==SerieEndDate);
            if (!flag)
                return null;

            return _context.TeamsSeriesPlayers.Include(c => c.Player).Where(c => c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate).Select(c => c.Player).ToList();
        }

        public List<Team> GetPlayerTeams(Guid PlayerId)
        {
            var flagPlayer = _context.Players.Any(c => c.Id == PlayerId);
            if (!flagPlayer)
                return null;
            List<Team> teams = _context.TeamsSeriesPlayers.Include(c => c.TeamSerie).Where(c => c.PlayerId == PlayerId).Select(c => c.TeamSerie).ToList();
            return teams;
        }
        public List<Player> GetPlayersOfTeamInSerie(Guid TeamId, Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate)
        {
            bool teamSP = _context.TeamsSeriesPlayers.Any(c => c.TeamSerieId == TeamId && c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate);
            if (!teamSP)
                return null;
            return _context.TeamsSeriesPlayers.Include(c => c.Player).Where(c => c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate && c.TeamSerieId == TeamId).Select(c => c.Player).ToList();
        }

        public List<Player> GetTeamPlayers(Guid TeamId)
        {
            var aux = _context.TeamsSeriesPlayers.Any(c => c.TeamSerieId == TeamId);
            if (!aux)
                return null;
            List<Player> players = _context.TeamsSeriesPlayers.Include(c => c.Player).Where(c => c.TeamSerieId == TeamId).Select(c => c.Player).Distinct().ToList();
            
            return players; 
        }

        public TeamSeriePlayer GetTeamSeriePlayer(Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate, Guid PlayerId)
        {
            return _context.TeamsSeriesPlayers.Include(c => c.Serie).Include(c => c.Player).Include(c => c.TeamSerie).SingleOrDefault(c => c.PlayerId == PlayerId && c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate);
        }


        public List<TeamSeriePlayer> GetTeamsSeriesPlayers()
        {
            return _context.TeamsSeriesPlayers.ToList();
        }

        public bool RemoveTeamSeriePlayer(TeamSeriePlayer teamSeriePlayer)
        {
            var currTeamSeriePlayer = _context.TeamsSeriesPlayers.SingleOrDefault(c => c.PlayerId == teamSeriePlayer.PlayerId && c.SerieId == teamSeriePlayer.SerieId && c.SerieInitDate == teamSeriePlayer.SerieInitDate && c.SerieEndDate == teamSeriePlayer.SerieEndDate);
            if(currTeamSeriePlayer == null)
            {
                return false;
            }
            foreach (var change in _context.PlayersChangesGames.Where(c => c.GameSerieId == teamSeriePlayer.SerieId && c.GameSerieInitDate == teamSeriePlayer.SerieInitDate && c.GameSerieEndDate == teamSeriePlayer.SerieEndDate && (c.PlayerInId == teamSeriePlayer.PlayerId || c.PlayerOutId == teamSeriePlayer.PlayerId)))
                _context.PlayersChangesGames.Remove(change);
            foreach (var game in _context.Games.Where(c => c.SerieId == teamSeriePlayer.SerieId && c.SerieInitDate == teamSeriePlayer.SerieInitDate && c.SerieEndDate == teamSeriePlayer.SerieEndDate && (c.PitcherWinerId == teamSeriePlayer.PlayerId || c.PitcherLoserId == teamSeriePlayer.PlayerId)))
                _context.Games.Remove(game);
            foreach (var stp in _context.StarPositionPlayersSeries.Where(c => c.SerieId == teamSeriePlayer.SerieId && c.SerieInitDate == teamSeriePlayer.SerieInitDate && c.SerieEndDate == teamSeriePlayer.SerieEndDate && c.PlayerId == teamSeriePlayer.PlayerId))
                _context.StarPositionPlayersSeries.Remove(stp);
            _context.TeamsSeriesPlayers.Remove(currTeamSeriePlayer);
            _context.SaveChanges();
            return true;
        }

        public TeamSeriePlayer UpdateTeamSeriePlayer(TeamSeriePlayer teamSeriePlayer)
        {
            var currTeamSeriePlayer = _context.TeamsSeriesPlayers.SingleOrDefault(c => c.PlayerId == teamSeriePlayer.PlayerId && c.SerieId == teamSeriePlayer.SerieId && c.SerieInitDate == teamSeriePlayer.SerieInitDate && c.SerieEndDate == teamSeriePlayer.SerieEndDate);
            if (currTeamSeriePlayer == null)
            {
                return null;
            }
            currTeamSeriePlayer.TeamSerieId = teamSeriePlayer.TeamSerieId;
            _context.TeamsSeriesPlayers.Update(currTeamSeriePlayer);
            _context.SaveChanges();
            return currTeamSeriePlayer;
        }

        public List<Player> GetPitchersTeamInSerie(Guid teamId, Guid SerieId, DateTime InitDate, DateTime EndDate)
        {
            var flag = _context.TeamsSeriesPlayers.Any(c => c.TeamSerieId == teamId && c.SerieId == SerieId && c.SerieInitDate == InitDate && c.SerieEndDate == EndDate);
            if (!flag)
                return null;
            Position pitcher = _context.Positions.SingleOrDefault(c => c.PositionName == "P");
            var allPitchersIDs = _context.Players.Where(c => c.PositionId == pitcher.Id).Select(c => c.Id).ToList();
            return _context.TeamsSeriesPlayers.Include(c => c.Player).Where(c => c.TeamSerieId == teamId && c.SerieId == SerieId && c.SerieInitDate == InitDate && c.SerieEndDate == EndDate && allPitchersIDs.Contains(c.PlayerId) ).Select(c => c.Player).ToList();
        }
    }
}
