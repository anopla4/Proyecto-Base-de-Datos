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
            bool flagPitcherWiner = _context.TeamsSeriesPlayers.Any(c => c.SerieId == game.SerieId && c.TeamSerieId == game.WinerTeamId && c.PlayerId == game.PitcherWinerPlayerId);
            if (!flagPitcherWiner)
                return null;
            bool flagPitcherLoser = _context.TeamsSeriesPlayers.Any(c => c.SerieId == game.SerieId && c.TeamSerieId == game.LoserTeamId && c.PlayerId == game.PitcherLoserPlayerId);
            if (!flagPitcherLoser)
                return null;
            bool flagWonGames = (_context.TeamsSeries.SingleOrDefault(c => c.TeamId == game.WinerTeamId && c.SerieId == game.SerieId).WonGames >= _context.Games.Where(c => c.SerieId == game.SerieId && c.WinerTeamId == game.WinerTeamId).ToList().Count);
            if (!flagWonGames)
                return null;
            bool flagLostGames = (_context.TeamsSeries.SingleOrDefault(c => c.TeamId == game.LoserTeamId && c.SerieId == game.SerieId).LostGames >= _context.Games.Where(c => c.SerieId == game.SerieId && c.LoserTeamId == game.LoserTeamId).ToList().Count);
            if (!flagLostGames)
                return null;
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

        public List<Game> GetGames(Guid SerieId)
        {
            var flag = _context.Games.Any(c => c.SerieId == SerieId);
            if (!flag)
                return null;
            return _context.Games.Include(c => c.Serie).Include(c => c.WinerTeam).Include(c => c.LoserTeam).Include(c => c.PitcherWiner).Include(c => c.PitcherLoser).Where(c => c.SerieId == SerieId).ToList();
        }

        public bool RemoveGame(Game game)
        {
            var currentGame = _context.Games.SingleOrDefault(c => c.GameId == game.GameId && c.SerieId == c.SerieId && c.SerieInitDate == game.SerieInitDate && c.WinerTeamId == game.WinerTeamId && c.LoserTeamId == game.LoserTeamId && c.GameTime == game.GameTime && c.GameDate == game.GameDate);
            if (currentGame == null)
                return false;
            _context.Games.Remove(currentGame);
            _context.SaveChanges();
            return true;
        }

        public Game UpdateGame(Game game)
        {
            var currentGame = _context.Games.SingleOrDefault(c => c.GameId == game.GameId && c.SerieId == c.SerieId && c.SerieInitDate == game.SerieInitDate && c.WinerTeamId == game.WinerTeamId && c.LoserTeamId == game.LoserTeamId && c.GameTime == game.GameTime && c.GameDate == game.GameDate);
            if (currentGame == null)
                return null;
            currentGame.PitcherWinerPlayerId = game.PitcherWinerPlayerId;
            currentGame.PitcherLoserPlayerId = game.PitcherLoserPlayerId;
            currentGame.InFavorCarrers = game.InFavorCarrers;
            currentGame.AgaintsCarrers = game.AgaintsCarrers;
            _context.Games.Update(currentGame);
            _context.SaveChanges();
            return currentGame;
        }
    }
}
