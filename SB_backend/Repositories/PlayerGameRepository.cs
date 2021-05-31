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

            List<PlayerGame> lineup = _context.PlayersGames.Include(c => c.Player).Include(c => c.Position).Where(c => c.gameGameId == GameId).ToList();

            if (lineup.Count == 0)
                return null;
            return lineup;
        }

        public List<PlayerGame> GetPlayersInGameWinerTeam(Guid GameId)
        {
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            if (game == null)
                return null;
            List<Guid> teamWIDS = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamSerieId == game.WinerTeamId).Select(c => c.PlayerId).ToList();
            if (teamWIDS.Count == 0)
                return null;
            List <PlayerGame> lineupWT = _context.PlayersGames.Include(c => c.Player).Include(c => c.Position).Where(c => c.gameGameId == GameId && teamWIDS.Contains(c.PlayerId)).ToList();
            return lineupWT;
        }

        public List<PlayerGame> GetPlayersInGameLoserTeam(Guid GameId)
        {
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            if (game == null)
                return null;
            List<Guid> teamLIDS = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamSerieId == game.LoserTeamId).Select(d => d.PlayerId).ToList();
            if (teamLIDS.Count == 0)
                return null;
            List<PlayerGame> lineupLT = _context.PlayersGames.Include(c => c.Player).Include(c => c.Position).Where(c => c.gameGameId == GameId && teamLIDS.Contains(c.PlayerId)).ToList();
            return lineupLT;
        }

        public PlayerGame GetPlayerInGame(Guid GameId, Guid PlayerId, Guid PositionId)
        {
            var plInGame = _context.PlayersGames.SingleOrDefault(c => c.gameGameId == GameId && c.PlayerId == PlayerId && c.PositionId == PositionId);
            return plInGame;
        }

        public PlayerGame AddPositionPlayerInGame(PlayerGame PlayerGame)
        {
            Game game = _context.Games.SingleOrDefault(c => c.GameId == PlayerGame.gameGameId && c.SerieId == PlayerGame.gameSerieId && c.SerieInitDate == PlayerGame.gameSerieInitDate && c.SerieEndDate == PlayerGame.gameSerieEndDate && c.WinerTeamId == PlayerGame.gameWinerTeamId && c.LoserTeamId == PlayerGame.gameLoserTeamId);
            if (game == null)
                return null;
            bool flagPlayer = _context.TeamsSeriesPlayers.Any(c => c.SerieId == game.SerieId && (c.TeamSerieId == game.WinerTeamId || c.TeamSerieId == game.LoserTeamId) && c.PlayerId == PlayerGame.PlayerId);
            if (!flagPlayer)
                return null;
            //_context.PlayersGames.Where(c => c.GameId == PlayerGame.GameId && c.PositionPlayerPositionId == PlayerGame.PositionPlayerPositionId).Select(c => c.PositionPlayerPlayerId).ToList();
            Position position = _context.Positions.Find(PlayerGame.PositionId);
            bool flagPlayerPosition = _context.Players.Include(c => c.Positions).Any(c => c.Id == PlayerGame.PlayerId && c.Positions.Contains(position));
            if (!flagPlayerPosition)
                return null;
            
            _context.PlayersGames.Add(PlayerGame);
            _context.SaveChanges();
            return PlayerGame;
        }

        public PlayerGame UpdatePlayerInGameWinerTeam(PlayerGame PlayerGame)
        {
            Game game = _context.Games.SingleOrDefault(c => c.GameId == PlayerGame.gameGameId && c.SerieId == PlayerGame.gameSerieId && c.SerieInitDate == PlayerGame.gameSerieInitDate && c.SerieEndDate == PlayerGame.gameSerieEndDate && c.WinerTeamId == PlayerGame.gameWinerTeamId && c.LoserTeamId == PlayerGame.gameLoserTeamId);
            if (game == null)
                return null;
            Guid teamId = _context.TeamsSeriesPlayers.Find(PlayerGame.PlayerId, PlayerGame.gameSerieId, PlayerGame.gameSerieInitDate, PlayerGame.gameSerieEndDate).TeamSerieId;
            if (teamId != PlayerGame.gameWinerTeamId)
                return null;

            Position position = _context.Positions.Find(PlayerGame.PositionId);
            bool flagPlayerPosition = _context.Players.Include(c => c.Positions).Any(c => c.Id == PlayerGame.PlayerId && c.Positions.Contains(position));
            if (!flagPlayerPosition)
                return null;
            List<Guid> teamWIDS = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamSerieId == game.WinerTeamId).Select(c => c.PlayerId).ToList();
            var currPlayerGame = _context.PlayersGames.SingleOrDefault(c => c.gameGameId == game.GameId && c.gameSerieId == PlayerGame.gameSerieId && c.gameSerieInitDate == PlayerGame.gameSerieInitDate && c.gameSerieEndDate == PlayerGame.gameSerieEndDate && c.gameWinerTeamId == PlayerGame.gameWinerTeamId && c.gameLoserTeamId == PlayerGame.gameLoserTeamId && teamWIDS.Contains(c.PlayerId));
            if (currPlayerGame == null)
                return null;
            currPlayerGame.PlayerId = PlayerGame.PlayerId;
            _context.PlayersGames.Update(currPlayerGame);
            _context.SaveChanges();
            return currPlayerGame;
        }

        public PlayerGame UpdatePlayerInGameLoserTeam(PlayerGame PlayerGame)
        {
            Game game = _context.Games.SingleOrDefault(c => c.GameId == PlayerGame.gameGameId && c.SerieId == PlayerGame.gameSerieId && c.SerieInitDate == PlayerGame.gameSerieInitDate && c.SerieEndDate == PlayerGame.gameSerieEndDate && c.WinerTeamId == PlayerGame.gameWinerTeamId && c.LoserTeamId == PlayerGame.gameLoserTeamId);
            if (game == null)
                return null;
            Guid teamId = _context.TeamsSeriesPlayers.Find(PlayerGame.PlayerId, PlayerGame.gameSerieId, PlayerGame.gameSerieInitDate, PlayerGame.gameSerieEndDate).TeamSerieId;
            if (teamId != PlayerGame.gameLoserTeamId)
                return null;

            Position position = _context.Positions.Find(PlayerGame.PositionId);
            bool flagPlayerPosition = _context.Players.Include(c => c.Positions).Any(c => c.Id == PlayerGame.PlayerId && c.Positions.Contains(position));
            if (!flagPlayerPosition)
                return null;
            List<Guid> teamLIDS = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamSerieId == game.LoserTeamId).Select(c => c.PlayerId).ToList();
            var currPlayerGame = _context.PlayersGames.SingleOrDefault(c => c.gameGameId == game.GameId && c.gameSerieId == PlayerGame.gameSerieId && c.gameSerieInitDate == PlayerGame.gameSerieInitDate && c.gameSerieEndDate == PlayerGame.gameSerieEndDate && c.gameWinerTeamId == PlayerGame.gameWinerTeamId && c.gameLoserTeamId == PlayerGame.gameLoserTeamId && teamLIDS.Contains(c.PlayerId));
            if (currPlayerGame == null)
                return null;

            currPlayerGame.PlayerId = PlayerGame.PlayerId;
            
            _context.PlayersGames.Update(currPlayerGame);
            _context.SaveChanges();
            return currPlayerGame;
        }

        public bool DeletePlayerInGame(PlayerGame PlayerGame)
        {
            var currPlayerGame = _context.PlayersGames.SingleOrDefault(c => c.gameGameId == PlayerGame.gameGameId && c.gameSerieId == PlayerGame.gameSerieId && c.gameSerieInitDate == PlayerGame.gameSerieInitDate && c.gameSerieEndDate == PlayerGame.gameSerieEndDate && c.gameWinerTeamId == PlayerGame.gameWinerTeamId && c.gameLoserTeamId == PlayerGame.gameLoserTeamId && c.PositionId == PlayerGame.PositionId && c.PlayerId == PlayerGame.PlayerId);
            if (currPlayerGame == null)
                return false;
            foreach (var change in _context.PlayersChangesGames.Where(c => c.PlayerOutId == PlayerGame.PlayerId))
                _context.PlayersChangesGames.Remove(change);
            _context.PlayersGames.Remove(currPlayerGame);
            _context.SaveChanges();
            return true;
        }

    }
}
