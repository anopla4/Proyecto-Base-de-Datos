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
        public PlayerChangeGame AddChangeInGame(PlayerChangeGame PlayerChangeGame)
        {
            var flagGame = _context.Games.Any(c => c.GameId == PlayerChangeGame.GameGameId && c.GameDate == PlayerChangeGame.GameGameDate && c.GameTime == PlayerChangeGame.GameGameTime && c.WinerTeamId == PlayerChangeGame.GameWinerTeamId && c.LoserTeamId == PlayerChangeGame.GameLoserTeamId && c.SerieId == PlayerChangeGame.GameSerieId && c.SerieInitDate == PlayerChangeGame.GameSerieInitDate && c.SerieEndDate == PlayerChangeGame.GameSerieEndDate);
            if (!flagGame)
                return null;
            List<Guid> teamLoser = _context.TeamsSeriesPlayers.Where(d => d.SerieId == PlayerChangeGame.GameSerieId && d.TeamSerieId == PlayerChangeGame.GameLoserTeamId).Select(d => d.PlayerId).ToList();
            List<Guid> teamWiner = _context.TeamsSeriesPlayers.Where(d => d.SerieId == PlayerChangeGame.GameSerieId && d.TeamSerieId == PlayerChangeGame.GameWinerTeamId).Select(d => d.PlayerId).ToList();
            Position position = _context.Positions.Find(PlayerChangeGame.PlayerInPositionId);
            if (PlayerChangeGame.PlayerInPositionId != PlayerChangeGame.PlayerOutPositionId)
                return null;
            var flagPlayerIn = (_context.Players.Any(c => c.Id == PlayerChangeGame.PlayerInId && c.PositionId == PlayerChangeGame.PlayerInPositionId) && 
                (teamLoser.Contains(PlayerChangeGame.PlayerInId) || teamLoser.Contains(PlayerChangeGame.PlayerInId)));
            if (!flagPlayerIn)
                return null;
            var flagPlayerOut = (_context.Players.Any(c => c.Id == PlayerChangeGame.PlayerOutId && c.PositionId == PlayerChangeGame.PlayerOutPositionId) &&
                (teamLoser.Contains(PlayerChangeGame.PlayerOutId) || teamLoser.Contains(PlayerChangeGame.PlayerOutId)));
            if (!flagPlayerOut)
                return null;
            if ((teamLoser.Contains(PlayerChangeGame.PlayerInId) && teamWiner.Contains(PlayerChangeGame.PlayerOutId)) || (teamLoser.Contains(PlayerChangeGame.PlayerOutId) && teamWiner.Contains(PlayerChangeGame.PlayerInId)))
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
            return _context.PlayersChangesGames.Include(c => c.PlayerIn).Include(c => c.PlayerIn.Position).Include(c => c.PlayerOut).Include(c => c.PlayerOut.Position).Include(c => c.Game).Where(c => c.GameGameId == GameId && teamLoser.Contains(c.PlayerInId)).ToList();
        }

        public List<PlayerChangeGame> GetPlayersChangesInGameWinerTeam(Guid GameId)
        {
            var flag = _context.PlayersChangesGames.Any(c => c.GameGameId == GameId);
            if (!flag)
                return null;
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            List<Guid> teamWiner = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamSerieId == game.WinerTeamId).Select(d => d.PlayerId).ToList();
            return _context.PlayersChangesGames.Include(c => c.PlayerIn).Include(c => c.PlayerIn.Position).Include(c => c.PlayerOut).Include(c => c.PlayerOut.Position).Include(c => c.Game).Where(c => c.GameGameId == GameId && teamWiner.Contains(c.PlayerInId)).ToList();
        }

        public bool RemoveChangeInGame(PlayerChangeGame PlayerChangeGame)
        {
            var currPlayerChange = _context.PlayersChangesGames.SingleOrDefault(c => c.GameGameId == PlayerChangeGame.GameGameId && c.PlayerInId == PlayerChangeGame.PlayerInId && c.PlayerInPositionId == PlayerChangeGame.PlayerInPositionId && c.PlayerOutId == PlayerChangeGame.PlayerOutId && c.PlayerOutPositionId == PlayerChangeGame.PlayerOutPositionId);
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
