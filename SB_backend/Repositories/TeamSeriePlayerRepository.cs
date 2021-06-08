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
            Team team = _context.Teams.Find(teamSeriePlayer.TeamId);
            if (team == null)
                throw new KeyNotFoundException("No se encuentra el equipo especificado");
            Serie serie = _context.Series.Find(teamSeriePlayer.SerieId, teamSeriePlayer.SerieInitDate, teamSeriePlayer.SerieEndDate);
            if (serie == null)
                throw new KeyNotFoundException("No se encuentra la serie especificada");
            bool player = _context.Players.Any(c => c.Id == teamSeriePlayer.PlayerId);
            if (!player)
                throw new KeyNotFoundException("No se encuentra el jugador especificado");
            _context.TeamsSeriesPlayers.Add(teamSeriePlayer);
            _context.SaveChanges();
            return teamSeriePlayer;
        }

        public List<Player> GetPlayersInSerie(Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate)
        {
            bool flag = _context.TeamsSeriesPlayers.Any(c => c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate ==SerieEndDate);
            if (!flag)
                throw new KeyNotFoundException("No se encuentra el jugador en la serie especificada como parte de este equipo");

            return _context.TeamsSeriesPlayers.Include(c => c.Player).Where(c => c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate).Select(c => c.Player).ToList();
        }

        public List<Team> GetPlayerTeams(Guid PlayerId)
        {
            var flagPlayer = _context.Players.Any(c => c.Id == PlayerId);
            if (!flagPlayer)
                throw new KeyNotFoundException("No se encuentra el jugador especificado");
            List<Team> teams = _context.TeamsSeriesPlayers.Include(c => c.Team).Where(c => c.PlayerId == PlayerId).Select(c => c.Team).ToList();
            return teams;
        }
        public List<Player> GetPlayersOfTeamInSerie(Guid TeamId, Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate)
        {
            bool teamSP = _context.TeamsSeriesPlayers.Any(c => c.TeamId == TeamId && c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate);
            if (!teamSP)
                throw new KeyNotFoundException("No se encuentra el jugador en la serie especificada como parte de este equipo");
            return _context.TeamsSeriesPlayers.Include(c => c.Player).Where(c => c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate && c.TeamId == TeamId).Select(c => c.Player).ToList();
        }

        public List<Player> GetTeamPlayers(Guid TeamId)
        {
            var aux = _context.TeamsSeriesPlayers.Any(c => c.TeamId == TeamId);
            if (!aux)
                throw new KeyNotFoundException("No se encuentra el jugador en la serie especificada como parte de este equipo");
            List<Player> players = _context.TeamsSeriesPlayers.Include(c => c.Player).Where(c => c.TeamId == TeamId).Select(c => c.Player).Distinct().ToList();
            
            return players; 
        }

        public TeamSeriePlayer GetTeamSeriePlayer(Guid SerieId, DateTime SerieInitDate, DateTime SerieEndDate, Guid PlayerId)
        {
            return _context.TeamsSeriesPlayers.Include(c => c.Serie).Include(c => c.Player).Include(c => c.Team).SingleOrDefault(c => c.PlayerId == PlayerId && c.SerieId == SerieId && c.SerieInitDate == SerieInitDate && c.SerieEndDate == SerieEndDate);
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
                throw new KeyNotFoundException("No se encuentra el jugador en la serie especificada como parte de este equipo");
            }
            foreach (var change in _context.PlayersChangesGames.Include(c=>c.Game).Where(c => c.Game.SerieId == teamSeriePlayer.SerieId && c.Game.SerieInitDate == teamSeriePlayer.SerieInitDate && c.Game.SerieEndDate == teamSeriePlayer.SerieEndDate && (c.PlayerIdIn == teamSeriePlayer.PlayerId || c.PlayerIdOut == teamSeriePlayer.PlayerId)))
                _context.PlayersChangesGames.Remove(change);
            foreach (var playerGame in _context.PlayersGames.Include(c => c.Game).Where(c => c.Game.SerieId == teamSeriePlayer.SerieId && c.Game.SerieInitDate == teamSeriePlayer.SerieInitDate && c.PlayerId == teamSeriePlayer.PlayerId))
                _context.PlayersGames.Remove(playerGame);
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
                throw new KeyNotFoundException("No se encuentra el jugador en la serie especificada como parte de este equipo");
            }
            currTeamSeriePlayer.TeamId = teamSeriePlayer.TeamId;
            _context.TeamsSeriesPlayers.Update(currTeamSeriePlayer);
            _context.SaveChanges();
            return currTeamSeriePlayer;
        }

        public List<Player> GetPitchersTeamInSerie(Guid teamId, Guid SerieId, DateTime InitDate, DateTime EndDate)
        {
            var flag = _context.TeamsSeriesPlayers.Any(c => c.TeamId == teamId && c.SerieId == SerieId && c.SerieInitDate == InitDate && c.SerieEndDate == EndDate);
            if (!flag)
                throw new KeyNotFoundException("No se encuentra el jugador en la serie especificada como parte de este equipo");
            Position pitcher = _context.Positions.SingleOrDefault(c => c.PositionName == "P");
            var allPitchersIDs = _context.PlayerPosition.Where(c => c.PositionId == pitcher.Id).Select(c => c.PlayerId).ToList();
            return _context.TeamsSeriesPlayers.Include(c => c.Player).Where(c => c.TeamId == teamId && c.SerieId == SerieId && c.SerieInitDate == InitDate && c.SerieEndDate == EndDate && allPitchersIDs.Contains(c.PlayerId) ).Select(c => c.Player).ToList();
        }
    }
}
