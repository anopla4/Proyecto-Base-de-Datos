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
                throw new KeyNotFoundException("La serie correspondiente a este juego no es válida");
            bool flagWinerTeam = _context.TeamsSeries.Any(c => c.SerieId == game.SerieId && c.TeamId == game.WinerTeamId);
            if (!flagWinerTeam)
                throw new KeyNotFoundException("El equipo ganador correspondiente a este juego no participa en la serie especificada.");
            bool flagLoserTeam = _context.TeamsSeries.Any(c => c.SerieId == game.SerieId && c.TeamId == game.LoserTeamId);
            if (!flagLoserTeam)
                throw new KeyNotFoundException("El equipo perdedor correspondiente a este juego no participa en la serie especificada.");
            if (game.WinerTeamId == game.LoserTeamId)
                throw new KeyNotFoundException("El equipo ganadore coincide con el equipo perdedor.");
            Position pitcher = _context.Positions.SingleOrDefault(c => c.PositionName == "P");
            List<Guid> positionsWinnerPitcher = _context.PlayerPosition
                .Where(c => c.PlayerId == game.PitcherWinerId)
                .Select(c=>c.PositionId).ToList();
            List<Guid> positionsLoserPitcher = _context.PlayerPosition
                .Where(c => c.PlayerId == game.PitcherLoserId)
                .Select(c => c.PositionId).ToList();
            if (!positionsWinnerPitcher.Contains(pitcher.Id))
                throw new KeyNotFoundException("El Pitcher ganador no es válido.");
            if (!positionsLoserPitcher.Contains(pitcher.Id))
                throw new KeyNotFoundException("El Pitcher perdedor no es válido.");

            if (!_context.TeamsSeriesPlayers.Any(c => c.SerieId == game.SerieId && c.TeamId == game.WinerTeamId && c.PlayerId == game.PitcherWinerId))
                throw new KeyNotFoundException("El Pitcher ganador no es válido. No forma parte del equipo ganador del juego en la serie especificada.");

            if (!_context.TeamsSeriesPlayers.Any(c => c.SerieId == game.SerieId && c.TeamId == game.LoserTeamId && c.PlayerId == game.PitcherLoserId))
                throw new KeyNotFoundException("El Pitcher ganador no es válido. No forma parte del equipo ganador del juego en la serie especificada.");

            bool flagWonGames = (_context.TeamsSeries.SingleOrDefault(c => c.TeamId == game.WinerTeamId && c.SerieId == game.SerieId).WonGames >= _context.Games.Where(c => c.SerieId == game.SerieId && c.WinerTeamId == game.WinerTeamId).ToList().Count);
            if (!flagWonGames)
                throw new FormatException("El Equipo ganador no es válido."); 
            bool flagLostGames = (_context.TeamsSeries.SingleOrDefault(c => c.TeamId == game.LoserTeamId && c.SerieId == game.SerieId).LostGames >= _context.Games.Where(c => c.SerieId == game.SerieId && c.LoserTeamId == game.LoserTeamId).ToList().Count);
            if (!flagLostGames)
                throw new FormatException("El Equipo perdedor no es válido.");

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
            if (game == null)
                throw new KeyNotFoundException("No se encuentra el juego especificado"); 
            return game;
        }

        public List<Game> GetGames()
        {
            return _context.Games.Include(c => c.Serie).Include(c => c.WinerTeam).Include(c => c.LoserTeam).Include(c => c.PitcherWiner).Include(c => c.PitcherLoser).ToList();
        }

        public List<Game> GetGames(Guid SerieId, DateTime InitDate, DateTime EndDate)
        {
            var flag = _context.Games.Any(c => c.SerieId == SerieId && c.SerieInitDate == InitDate && c.SerieEndDate == EndDate);
            if (_context.Series.Find(SerieId, InitDate, EndDate) == null)
                throw new KeyNotFoundException("No se encuentra la serie especificada.");
            return _context.Games.Include(c => c.Serie).Include(c => c.WinerTeam).Include(c => c.LoserTeam).Include(c => c.PitcherWiner).Include(c => c.PitcherLoser).Where(c => c.SerieId == SerieId && c.SerieInitDate == InitDate && c.SerieEndDate == EndDate).ToList();
        }

        public bool RemoveGame(Game game)
        {
            var currentGame = _context.Games.SingleOrDefault(c => c.GameId == game.GameId && c.SerieId == game.SerieId && c.SerieInitDate == game.SerieInitDate);
            if (currentGame == null)
                throw new KeyNotFoundException("El juego no es válido.");
            foreach (var change in _context.PlayersChangesGames.Include(c=>c.Game).Where(c => c.GameId == game.GameId))
                _context.PlayersChangesGames.Remove(change);
            foreach (var playerGame in _context.PlayersGames.Include(c => c.Game).Where(c => c.GameId == game.GameId))
                _context.PlayersGames.Remove(playerGame);
            _context.Games.Remove(currentGame);
            _context.SaveChanges();
            return true;
        }

        public Game UpdateGame(Game game)
        {
            var currentGame = _context.Games.SingleOrDefault(c => c.GameId == game.GameId && c.SerieId == c.SerieId && c.SerieInitDate == game.SerieInitDate);
            if (currentGame == null)
                throw new KeyNotFoundException("No se enccuentra el juego especificado");
            currentGame.PitcherWinerId = game.PitcherWinerId;
            currentGame.PitcherLoserId = game.PitcherLoserId;
            currentGame.InFavorCarrers = game.InFavorCarrers;
            currentGame.AgainstCarrers = game.AgainstCarrers;
            _context.Games.Update(currentGame);
            _context.SaveChanges();
            return currentGame;
        }
    }
}
