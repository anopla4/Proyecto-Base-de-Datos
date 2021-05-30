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
        public PlayerChangeGame AddChangeInGame(PlayerChangeGame PlayerChangeGame)
        {
            var flagGame = _context.Games.Any(c => c.GameId == PlayerChangeGame.GameGameId && c.GameDate == PlayerChangeGame.GameGameDate && c.GameTime == PlayerChangeGame.GameGameTime && c.WinerTeamId == PlayerChangeGame.GameWinerTeamId && c.LoserTeamId == PlayerChangeGame.GameLoserTeamId && c.SerieId == PlayerChangeGame.GameSerieId && c.SerieInitDate == PlayerChangeGame.GameSerieInitDate && c.SerieEndDate == PlayerChangeGame.GameSerieEndDate);
            if (!flagGame)
                return null;
            List<Guid> teamLoser = _context.TeamsSeriesPlayers.Where(d => d.SerieId == PlayerChangeGame.GameSerieId && d.TeamSerieId == PlayerChangeGame.GameLoserTeamId).Select(d => d.PlayerId).ToList();
            List<Guid> teamWiner = _context.TeamsSeriesPlayers.Where(d => d.SerieId == PlayerChangeGame.GameSerieId && d.TeamSerieId == PlayerChangeGame.GameWinerTeamId).Select(d => d.PlayerId).ToList();
            var flagPlayerIn = (_context.PositionPlayers.Any(c => c.PlayerId == PlayerChangeGame.PlayerInPlayerId && c.PositionId == PlayerChangeGame.PlayerInPositionId) && 
                (teamLoser.Contains(PlayerChangeGame.PlayerInPlayerId) || teamLoser.Contains(PlayerChangeGame.PlayerInPlayerId)));
            if (!flagPlayerIn)
                return null;
            var flagPlayerOut = (_context.PositionPlayers.Any(c => c.PlayerId == PlayerChangeGame.PlayerOutPlayerId && c.PositionId == PlayerChangeGame.PlayerInPositionId) &&
                (teamLoser.Contains(PlayerChangeGame.PlayerOutPlayerId) || teamLoser.Contains(PlayerChangeGame.PlayerOutPlayerId)));
            if (!flagPlayerOut)
                return null;
            if ((teamLoser.Contains(PlayerChangeGame.PlayerInPlayerId) && teamWiner.Contains(PlayerChangeGame.PlayerOutPlayerId)) || (teamLoser.Contains(PlayerChangeGame.PlayerOutPlayerId) && teamWiner.Contains(PlayerChangeGame.PlayerInPlayerId)))
                return null;
            _context.PlayersChangesGames.Add(PlayerChangeGame);
            _context.SaveChanges();
            return PlayerChangeGame;
        }

        public List<PlayerChangeGame> GetPlayersChangesGames()
        {
            return _context.PlayersChangesGames.ToList();
        }

        public List<PlayerChangeGame> GetPlayersChangesInGame(Guid GameId)
        {
            var flag = _context.PlayersChangesGames.Any(c => c.GameGameId == GameId);
            if (!flag)
                return null;
            return _context.PlayersChangesGames.Where(c => c.GameGameId == GameId).ToList();

        }

        public List<PlayerChangeGame> GetPlayersChangesInGameLoserTeam(Guid GameId)
        {
            var flag = _context.PlayersChangesGames.Any(c => c.GameGameId == GameId);
            if (!flag)
                return null;
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            List<Guid> teamLoser = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamSerieId == game.LoserTeamId).Select(d => d.PlayerId).ToList();
            return _context.PlayersChangesGames.Where(c => c.GameGameId == GameId && teamLoser.Contains(c.PlayerInPlayerId)).ToList();
        }

        public List<PlayerChangeGame> GetPlayersChangesInGameWinerTeam(Guid GameId)
        {
            var flag = _context.PlayersChangesGames.Any(c => c.GameGameId == GameId);
            if (!flag)
                return null;
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            List<Guid> teamWiner = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamSerieId == game.WinerTeamId).Select(d => d.PlayerId).ToList();
            return _context.PlayersChangesGames.Where(c => c.GameGameId == GameId && teamWiner.Contains(c.PlayerInPlayerId)).ToList();
        }

        public bool RemoveChangeInGame(PlayerChangeGame PlayerChangeGame)
        {
            var currPlayerChange = _context.PlayersChangesGames.SingleOrDefault(c => c.GameGameId == PlayerChangeGame.GameGameId && c.PlayerInPlayerId == PlayerChangeGame.PlayerInPlayerId && c.PlayerInPositionId == PlayerChangeGame.PlayerInPositionId && c.PlayerOutPlayerId == PlayerChangeGame.PlayerOutPlayerId && c.PlayerOutPositionId == PlayerChangeGame.PlayerOutPositionId);
            if (currPlayerChange == null)
                return false;
            _context.PlayersChangesGames.Remove(currPlayerChange);
            _context.SaveChanges();
            return true;
        }

        public PlayerChangeGame UpdateChangeInGameLoserTeam(PlayerChangeGame PlayerChangeGame)
        {
            return null;
        }

        public PlayerChangeGame UpdateChangeInGameWinerTeam(PlayerChangeGame PlayerChangeGame)
        {
            throw new NotImplementedException();
        }
    }
}
