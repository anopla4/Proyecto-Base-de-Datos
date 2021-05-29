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
            Serie serie = _context.Series.Find(teamSeriePlayer.SerieId);
            if (serie == null)
                return null;
            Player player = _context.Players.Find(teamSeriePlayer.PlayerId);
            if (player == null)
                return null;
            _context.TeamsSeriesPlayers.Add(teamSeriePlayer);
            _context.SaveChanges();
            return teamSeriePlayer;
        }

        public List<Player> GetPlayersInSerie(Guid SerieId)
        {
            bool flag = _context.TeamsSeriesDirectors.Any(c => c.TeamSerieId == SerieId);
            if (!flag)
                return null;
            return null;
        }

        public List<Player> GetPlayersOfTeamInSerie(Guid TeamId, Guid SerieId)
        {
            bool teamSP = _context.TeamsSeriesPlayers.Any(c => c.TeamSerieId == TeamId && c.SerieId == SerieId);
            if (!teamSP)
                return null;
            return _context.TeamsSeriesPlayers.Include(c => c.Player).Where(c => c.SerieId == SerieId && c.TeamSerieId == TeamId).Select(c => c.Player).ToList();
        }

        public List<Player> GetTeamPlayers(Guid TeamId)
        {
            var aux = _context.TeamsSeriesPlayers.Any(c => c.TeamSerieId == TeamId);
            if (!aux)
                return null;
            List<Player> players = _context.TeamsSeriesPlayers.Include(c => c.Player).Where(c => c.TeamSerieId == TeamId).Select(c => c.Player).ToList();
            return players; 
        }

        public TeamSeriePlayer GetTeamSeriePlayer(Guid SerieId, Guid PlayerId)
        {
            return _context.TeamsSeriesPlayers.Include(c => c.Serie).Include(c => c.Player).Include(c => c.TeamSerie).SingleOrDefault(c => c.PlayerId == PlayerId && c.SerieId == SerieId);
        }


        public List<TeamSeriePlayer> GetTeamsSeriesPlayers()
        {
            return _context.TeamsSeriesPlayers.ToList();
        }

        public bool RemoveTeamSeriePlayer(TeamSeriePlayer teamSeriePlayer)
        {
            var currTeamSeriePlayer = _context.TeamsSeriesPlayers.SingleOrDefault(c => c.PlayerId == teamSeriePlayer.PlayerId && c.SerieId == teamSeriePlayer.SerieId);
            if(currTeamSeriePlayer == null)
            {
                return false;
            }
            _context.TeamsSeriesPlayers.Remove(currTeamSeriePlayer);
            _context.SaveChanges();
            return true;
        }

        public TeamSeriePlayer UpdateTeamSeriePlayer(TeamSeriePlayer teamSeriePlayer)
        {
            var currTeamSeriePlayer = _context.TeamsSeriesPlayers.SingleOrDefault(c => c.PlayerId == teamSeriePlayer.PlayerId && c.SerieId == teamSeriePlayer.SerieId);
            if (currTeamSeriePlayer == null)
            {
                return null;
            }
            currTeamSeriePlayer.TeamSerieId = teamSeriePlayer.TeamSerieId;
            _context.TeamsSeriesPlayers.Update(currTeamSeriePlayer);
            _context.SaveChanges();
            return currTeamSeriePlayer;
        }
    }
}
