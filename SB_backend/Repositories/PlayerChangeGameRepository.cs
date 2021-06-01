using Microsoft.EntityFrameworkCore;
using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class PlayerChangeGameRepository : IPlayerChangeGameRepository
    {
        private AppDBContext _context;
        public PlayerChangeGameRepository(AppDBContext context)
        {
            _context = context;
        }
        public PlayerChangeGame AddChangeInGame(PlayerChangeGame playerChangeGame)
        {
            var game = _context.Games.Find(playerChangeGame.GameId);
            if (game == null)
                return null;
            List<Guid> teamLoser = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamId == game.LoserTeamId).Select(d => d.PlayerId).ToList();
            List<Guid> teamWiner = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamId == game.WinerTeamId).Select(d => d.PlayerId).ToList();
            var playerPositionInFlag = _context.PlayerPosition.Any(c => c.PlayerId == playerChangeGame.PositionIdIn && c.PositionId == playerChangeGame.PositionIdOut);
            if (!playerPositionInFlag)
                return null;

            if (playerChangeGame.PositionIdIn != playerChangeGame.PositionIdOut)
                return null;
            if ((teamWiner.Contains(playerChangeGame.PlayerIdIn) && teamWiner.Contains(playerChangeGame.PlayerIdOut)) || (teamLoser.Contains(playerChangeGame.PlayerIdOut) && teamLoser.Contains(playerChangeGame.PlayerIdIn)))
                return null;

            var isValidPlayerOut = _context.PlayersGames.Any(c => c.GameId == playerChangeGame.GameId && c.PlayerId == playerChangeGame.PlayerIdOut) 
                || _context.PlayersChangesGames.Any(c => c.GameId == playerChangeGame.GameId && c.PlayerIdIn == playerChangeGame.PlayerIdOut);

            if (!isValidPlayerOut)
                return null;

            _context.PlayersChangesGames.Add(playerChangeGame);
            _context.SaveChanges();
            return playerChangeGame;
        }

        public List<PlayerChangeGame> GetPlayersChangesGames()
        {
            return _context.PlayersChangesGames.ToList();
        }

        public List<PlayerChangeGame> GetPlayersChangesInGame(Guid GameId)
        {
            var flag = _context.PlayersChangesGames.Any(c => c.GameId == GameId);
            if (!flag)
                return null;
            return _context.PlayersChangesGames.Where(c => c.GameId == GameId).ToList();

        }

        public List<PlayerChangeGame> GetPlayersChangesInGameLoserTeam(Guid GameId)
        {
            var flag = _context.PlayersChangesGames.Any(c => c.GameId == GameId);
            if (!flag)
                return null;
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            List<Guid> teamLoser = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamId == game.LoserTeamId).Select(d => d.PlayerId).ToList();
            return _context.PlayersChangesGames.Include(c => c.PlayerPositionIn).Include(c => c.PlayerPositionOut).Include(c => c.Game).Where(c => c.GameId == GameId && teamLoser.Contains(c.PlayerIdIn)).ToList();
        }

        public List<PlayerChangeGame> GetPlayersChangesInGameWinerTeam(Guid GameId)
        {
            var flag = _context.PlayersChangesGames.Any(c => c.GameId == GameId);
            if (!flag)
                return null;
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            List<Guid> teamWiner = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamId == game.WinerTeamId).Select(d => d.PlayerId).ToList();
            return _context.PlayersChangesGames.Include(c => c.PlayerPositionIn).Include(c => c.PlayerPositionOut).Include(c => c.Game).Where(c => c.GameId == GameId && teamWiner.Contains(c.PlayerIdIn)).ToList();
        }

        public bool RemoveChangeInGame(Guid gameId, Guid playerInId, Guid positionIdIn, Guid playerOutId, Guid positionIdOut)
        {
            var currPlayerChange = _context.PlayersChangesGames.SingleOrDefault(c => c.GameId == gameId
            && c.PlayerIdIn == playerInId
            && c.PlayerIdOut == playerOutId
            && c.PositionIdIn == positionIdIn
            && c.PositionIdOut == positionIdOut);
            if (currPlayerChange == null)
                return false;
            _context.PlayersChangesGames.Remove(currPlayerChange);
            _context.SaveChanges();
            return true;
        }

    }
}
