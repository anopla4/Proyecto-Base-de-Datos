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

        public List<PositionPlayer> GetPlayersInGame(Guid GameId)
        {
            if (!_context.Games.Any(c => c.GameId == GameId))
                return null;

            List<PositionPlayer> lineup = _context.PlayersGames.Include(c => c.Game).Include(c => c.PositionPlayer).Where(c => c.GameId == GameId).Select(c => c.PositionPlayer).ToList();

            if (lineup.Count == 0)
                return null;
            return lineup;
        }

        public List<PositionPlayer> GetPlayersInGameWinerTeam(Guid GameId)
        {
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            if (game == null)
                return null;
            List<Guid> teamWIDS = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamSerieId == game.WinerTeamId).Select(c => c.PlayerId).ToList();
            if (teamWIDS.Count == 0)
                return null;
            List <PositionPlayer> lineupWT = _context.PlayersGames.Include(c => c.Game).Include(c => c.PositionPlayer).Where(c => c.GameId == GameId && teamWIDS.Contains(c.PositionPlayerPlayerId)).Select(c => c.PositionPlayer).ToList();
            return lineupWT;
        }

        public List<PositionPlayer> GetPlayersInGameLoserTeam(Guid GameId)
        {
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            if (game == null)
                return null;
            List<Guid> teamLIDS = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamSerieId == game.LoserTeamId).Select(d => d.PlayerId).ToList();
            if (teamLIDS.Count == 0)
                return null;
            List<PositionPlayer> lineupLT = _context.PlayersGames.Include(c => c.Game).Include(c => c.PositionPlayer).Where(c => c.GameId == GameId && teamLIDS.Contains(c.PositionPlayerPlayerId)).Select(c => c.PositionPlayer).ToList();
            return lineupLT;
        }

        public PlayerGame GetPlayerInGame(Guid GameId, Guid PlayerId, Guid PositionId)
        {
            var plInGame = _context.PlayersGames.SingleOrDefault(c => c.GameId == GameId && c.PositionPlayerPlayerId == PlayerId && c.PositionPlayerPositionId == PositionId);
            return plInGame;
        }

        public PlayerGame AddPositionPlayerInGame(PlayerGame PlayerGame)
        {
            Game game = _context.Games.SingleOrDefault(c => c.GameId == PlayerGame.GameId && c.SerieId == PlayerGame.SerieId && c.SerieInitDate == PlayerGame.SerieInitDate && c.SerieEndDate == PlayerGame.SerieEndDate && c.WinerTeamId == PlayerGame.WinerTeamId && c.LoserTeamId == PlayerGame.LoserTeamId);
            if (game == null)
                return null;
            bool flagPlayer = _context.TeamsSeriesPlayers.Any(c => c.SerieId == game.SerieId && (c.TeamSerieId == game.WinerTeamId || c.TeamSerieId == game.LoserTeamId) && c.PlayerId == PlayerGame.PositionPlayerPlayerId);
            if (!flagPlayer)
                return null;
            //_context.PlayersGames.Where(c => c.GameId == PlayerGame.GameId && c.PositionPlayerPositionId == PlayerGame.PositionPlayerPositionId).Select(c => c.PositionPlayerPlayerId).ToList();
            bool flagPlayerPosition = _context.PositionPlayers.Any(c => c.PlayerId == PlayerGame.PositionPlayerPlayerId && c.PositionId == PlayerGame.PositionPlayerPositionId);
            if (!flagPlayerPosition)
                return null;
            
            _context.PlayersGames.Add(PlayerGame);
            _context.SaveChanges();
            return PlayerGame;
        }

        public PlayerGame UpdatePlayerInGameWinerTeam(PlayerGame PlayerGame)
        {
            Game game = _context.Games.SingleOrDefault(c => c.GameId == PlayerGame.GameId && c.SerieId == PlayerGame.SerieId && c.SerieInitDate == PlayerGame.SerieInitDate && c.SerieEndDate == PlayerGame.SerieEndDate && c.WinerTeamId == PlayerGame.WinerTeamId && c.LoserTeamId == PlayerGame.LoserTeamId);
            if (game == null)
                return null;
            bool flagPlayer = _context.TeamsSeriesPlayers.Any(c => c.SerieId == game.SerieId && (c.TeamSerieId == game.WinerTeamId || c.TeamSerieId == game.LoserTeamId) && c.PlayerId == PlayerGame.PositionPlayerPlayerId);
            if (!flagPlayer)
                return null;
            bool flagPlayerPosition = _context.PositionPlayers.Any(c => c.PlayerId == PlayerGame.PositionPlayerPlayerId && c.PositionId == PlayerGame.PositionPlayerPositionId);
            if (!flagPlayerPosition)
                return null;
            var currPlayerGame = _context.PlayersGames.SingleOrDefault(c => c.GameId == game.GameId && c.PositionPlayerPositionId == PlayerGame.PositionPlayerPositionId && _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamSerieId == game.WinerTeamId).Select(d => d.PlayerId).ToList().Contains(c.PositionPlayerPlayerId));
            currPlayerGame.PositionPlayerPlayerId = PlayerGame.PositionPlayerPlayerId;
            if (currPlayerGame == null)
                return null;
            _context.PlayersGames.Update(currPlayerGame);
            _context.SaveChanges();
            return currPlayerGame;
        }

        public PlayerGame UpdatePlayerInGameLoserTeam(PlayerGame PlayerGame)
        {
            Game game = _context.Games.SingleOrDefault(c => c.GameId == PlayerGame.GameId && c.SerieId == PlayerGame.SerieId && c.SerieInitDate == PlayerGame.SerieInitDate && c.SerieEndDate == PlayerGame.SerieEndDate && c.WinerTeamId == PlayerGame.WinerTeamId && c.LoserTeamId == PlayerGame.LoserTeamId);
            if (game == null)
                return null;
            bool flagPlayer = _context.TeamsSeriesPlayers.Any(c => c.SerieId == game.SerieId && (c.TeamSerieId == game.WinerTeamId || c.TeamSerieId == game.LoserTeamId) && c.PlayerId == PlayerGame.PositionPlayerPlayerId);
            if (!flagPlayer)
                return null;
            bool flagPlayerPosition = _context.PositionPlayers.Any(c => c.PlayerId == PlayerGame.PositionPlayerPlayerId && c.PositionId == PlayerGame.PositionPlayerPositionId);
            if (!flagPlayerPosition)
                return null;
            var currPlayerGame = _context.PlayersGames.SingleOrDefault(c => c.GameId == game.GameId && c.PositionPlayerPositionId == PlayerGame.PositionPlayerPositionId && _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamSerieId == game.LoserTeamId).Select(d => d.PlayerId).ToList().Contains(c.PositionPlayerPlayerId));
            if (currPlayerGame == null)
                return null;
            currPlayerGame.PositionPlayerPlayerId = PlayerGame.PositionPlayerPlayerId;
            _context.PlayersGames.Update(currPlayerGame);
            _context.SaveChanges();
            return currPlayerGame;
        }

        public bool DeletePlayerInGame(PlayerGame PlayerGame)
        {
            Game game = _context.Games.SingleOrDefault(c => c.GameId == PlayerGame.GameId && c.SerieId == PlayerGame.SerieId && c.SerieInitDate == PlayerGame.SerieInitDate && c.SerieEndDate == PlayerGame.SerieEndDate && c.WinerTeamId == PlayerGame.WinerTeamId && c.LoserTeamId == PlayerGame.LoserTeamId);
            if (game == null)
                return false;
            var currPlayerGame = _context.PlayersGames.SingleOrDefault(c => c.GameId == game.GameId && c.PositionPlayerPositionId == PlayerGame.PositionPlayerPositionId && c.PositionPlayerPlayerId == PlayerGame.PositionPlayerPlayerId);
            if (currPlayerGame == null)
                return false;
            _context.PlayersGames.Remove(currPlayerGame);
            _context.SaveChanges();
            return true;
        }

    }
}
