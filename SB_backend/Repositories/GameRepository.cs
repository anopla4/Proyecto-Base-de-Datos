using Microsoft.EntityFrameworkCore;
using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class GameRepository: IGameRepository
    {
        private AppDBContext _context;
        public GameRepository(AppDBContext context)
        {
            _context = context;
        }

        public Game AddGame(Game game)
        {
            game.GameId = Guid.NewGuid();
            bool flagSerie = _context.Series.Any(c => c.Id == game.SerieId && c.InitDate == game.SerieInitDate && c.EndDate == game.SerieEndDate);
            if (!flagSerie)
                return null;
            bool flagWinerTeam = _context.TeamsSeries.Any(c => c.SerieId == game.SerieId && c.TeamId == game.WinerTeamId);
            if (!flagWinerTeam)
                return null;
            bool flagLoserTeam = _context.TeamsSeries.Any(c => c.SerieId == game.SerieId && c.TeamId == game.LoserTeamId);
            if (!flagLoserTeam)
                return null;
            if (game.WinerTeamId == game.LoserTeamId)
                return null;
            Position pitcher = _context.Positions.SingleOrDefault(c => c.PositionName == "P");
            List<Guid> positionsWinnerPitcher = _context.PlayerPosition
                .Where(c => c.PlayerId == game.PitcherWinerId)
                .Select(c=>c.PositionId).ToList();
            List<Guid> positionsLoserPitcher = _context.PlayerPosition
                .Where(c => c.PlayerId == game.PitcherLoserId)
                .Select(c => c.PositionId).ToList();
            if (!positionsWinnerPitcher.Contains(pitcher.Id))
                return null;
            if (!positionsLoserPitcher.Contains(pitcher.Id))
                return null;

            if (!_context.TeamsSeriesPlayers.Any(c => c.SerieId == game.SerieId && c.TeamId == game.WinerTeamId && c.PlayerId == game.PitcherWinerId))
                return null;

            if (!_context.TeamsSeriesPlayers.Any(c => c.SerieId == game.SerieId && c.TeamId == game.LoserTeamId && c.PlayerId == game.PitcherLoserId))
                return null;

            bool flagWonGames = (_context.TeamsSeries.SingleOrDefault(c => c.TeamId == game.WinerTeamId && c.SerieId == game.SerieId).WonGames >= _context.Games.Where(c => c.SerieId == game.SerieId && c.WinerTeamId == game.WinerTeamId).ToList().Count);
            if (!flagWonGames)
                return null;
            bool flagLostGames = (_context.TeamsSeries.SingleOrDefault(c => c.TeamId == game.LoserTeamId && c.SerieId == game.SerieId).LostGames >= _context.Games.Where(c => c.SerieId == game.SerieId && c.LoserTeamId == game.LoserTeamId).ToList().Count);
            if (!flagLostGames)
                return null;

            PlayerGame winnerPitcherplayerGame = new PlayerGame();
            winnerPitcherplayerGame.GameId = game.GameId;
            winnerPitcherplayerGame.PlayerId = game.PitcherWinerId;
            _context.PlayersGames.Add(winnerPitcherplayerGame);

            PlayerGame loserPitcherplayerGame = new PlayerGame();
            loserPitcherplayerGame.GameId = game.GameId;
            loserPitcherplayerGame.PlayerId = game.PitcherLoserId;
            _context.PlayersGames.Add(loserPitcherplayerGame);


            _context.Games.Add(game);
            _context.SaveChanges();
            return game;
        }

        public Game GetGame(Guid Id)
        {
            var game = _context.Games.Include(c => c.WinerTeam).Include(c => c.LoserTeam).Include(c => c.Serie).Include(c => c.PitcherWiner).Include(c => c.PitcherLoser).SingleOrDefault(c => c.GameId == Id);
            if (game != null)
                return null;
            return game;
        }

        public List<Game> GetGames()
        {
            return _context.Games.Include(c => c.Serie).Include(c => c.WinerTeam).Include(c => c.LoserTeam).Include(c => c.PitcherWiner).Include(c => c.PitcherLoser).ToList();
        }

        public List<Game> GetGames(Guid SerieId, DateTime InitDate, DateTime EndDate)
        {
            var flag = _context.Games.Any(c => c.SerieId == SerieId && c.SerieInitDate == InitDate && c.SerieEndDate == EndDate);
            if (!flag)
                return null;
            return _context.Games.Include(c => c.Serie).Include(c => c.WinerTeam).Include(c => c.LoserTeam).Include(c => c.PitcherWiner).Include(c => c.PitcherLoser).Where(c => c.SerieId == SerieId && c.SerieInitDate == InitDate && c.SerieEndDate == EndDate).ToList();
        }

        public bool RemoveGame(Game game)
        {
            var currentGame = _context.Games.SingleOrDefault(c => c.GameId == game.GameId && c.SerieId == game.SerieId && c.SerieInitDate == game.SerieInitDate);
            if (currentGame == null)
                return false;
            foreach (var change in _context.PlayersChangesGames.Include(c=>c.Game).Where(c => c.GameId == game.GameId && c.Game.SerieId == game.SerieId && c.Game.SerieInitDate == game.SerieInitDate))
                _context.PlayersChangesGames.Remove(change);

            _context.Games.Remove(currentGame);
            _context.SaveChanges();
            return true;
        }

        public Game UpdateGame(Game game)
        {
            var currentGame = _context.Games.SingleOrDefault(c => c.GameId == game.GameId && c.SerieId == c.SerieId && c.SerieInitDate == game.SerieInitDate);
            if (currentGame == null)
                return null;
            currentGame.PitcherWinerId = game.PitcherWinerId;
            currentGame.PitcherLoserId = game.PitcherLoserId;
            currentGame.InFavorCarrers = game.InFavorCarrers;
            currentGame.AgaintsCarrers = game.AgaintsCarrers;
            _context.Games.Update(currentGame);
            _context.SaveChanges();
            return currentGame;
        }
    }
}
