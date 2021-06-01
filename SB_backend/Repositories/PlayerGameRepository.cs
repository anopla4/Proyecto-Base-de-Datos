using Microsoft.EntityFrameworkCore;
using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class PlayerGameRepository: IPlayerGameRepository
    {
        private AppDBContext _context;
        public PlayerGameRepository(AppDBContext context)
        {
            _context = context;
        }
        public List<PlayerGame> GetPlayersGames()
        {
            return _context.PlayersGames.ToList();
        }

        public List<PlayerGame> GetPlayersInGame(Guid GameId)
        {
            if (!_context.Games.Any(c => c.GameId == GameId))
                return null;

            List<PlayerGame> lineup = _context.PlayersGames.Include(c => c.Player).Where(c => c.GameId == GameId).ToList();

            if (lineup.Count == 0)
                return null;
            return lineup;
        }

        public List<PlayerGame> GetPlayersInGameWinerTeam(Guid GameId)
        {
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            if (game == null)
                return null;
            List<Guid> teamWIDS = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamId == game.WinerTeamId).Select(c => c.PlayerId).ToList();
            if (teamWIDS.Count == 0)
                return null;
            List <PlayerGame> lineupWT = _context.PlayersGames.Include(c => c.Player).Where(c => c.GameId == GameId && teamWIDS.Contains(c.PlayerId)).ToList();
            return lineupWT;
        }

        public List<PlayerGame> GetPlayersInGameLoserTeam(Guid GameId)
        {
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            if (game == null)
                return null;
            List<Guid> teamLIDS = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamId == game.LoserTeamId).Select(d => d.PlayerId).ToList();
            if (teamLIDS.Count == 0)
                return null;
            List<PlayerGame> lineupLT = _context.PlayersGames.Include(c => c.Player).Where(c => c.GameId == GameId && teamLIDS.Contains(c.PlayerId)).ToList();
            return lineupLT;
        }

        public PlayerGame GetPlayerInGame(Guid GameId, Guid PlayerId)
        {
            var plInGame = _context.PlayersGames.SingleOrDefault(c => c.GameId == GameId && c.PlayerId == PlayerId);
            return plInGame;
        }

        public PlayerGame AddPlayerInGame(PlayerGame playerGame)
        {
            Game game = _context.Games.SingleOrDefault(c => c.GameId == playerGame.GameId);
            if (game == null)
                return null;
            bool flagPlayer = _context.TeamsSeriesPlayers.Any(c => c.SerieId == game.SerieId && (c.TeamId == game.WinerTeamId || c.TeamId == game.LoserTeamId) && c.PlayerId == playerGame.PlayerId);
            if (!flagPlayer)
                return null;
            bool flagPlayerPosition = _context.PlayerPosition.Any(c => c.PlayerId == playerGame.PlayerId);
            if (!flagPlayerPosition)
                return null;
            
            _context.PlayersGames.Add(playerGame);
            _context.SaveChanges();
            return playerGame;
        }

        public bool DeletePlayerInGame(PlayerGame playerGame)
        {
            var currPlayerGame = _context.PlayersGames.SingleOrDefault(c => c.GameId == playerGame.GameId && c.PlayerId == playerGame.PlayerId);
            if (currPlayerGame == null)
                return false;
            foreach (var change in _context.PlayersChangesGames.Where(c => c.PlayerIdIn == playerGame.PlayerId || c.PlayerIdOut== playerGame.PlayerId))
                _context.PlayersChangesGames.Remove(change);
            _context.PlayersGames.Remove(currPlayerGame);
            _context.SaveChanges();
            return true;
        }

    }
}
