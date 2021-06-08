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
                throw new KeyNotFoundException("No se encuentra el juego especificado.");
            List<Guid> teamLoser = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamId == game.LoserTeamId).Select(d => d.PlayerId).ToList();
            List<Guid> teamWiner = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamId == game.WinerTeamId).Select(d => d.PlayerId).ToList();
            var playerPositionInFlag = _context.PlayerPosition.Any(c => c.PlayerId == playerChangeGame.PlayerIdIn && c.PositionId == playerChangeGame.PositionIdOut);
            if (!playerPositionInFlag)
                throw new FormatException("No es valida la posición del cambio para el jugador que entra.");

            if (playerChangeGame.PositionIdIn != playerChangeGame.PositionIdOut)
                throw new FormatException("La posición del jugador que entra no coincide con la del que es cambiado.");
            if (!((teamWiner.Contains(playerChangeGame.PlayerIdIn) && teamWiner.Contains(playerChangeGame.PlayerIdOut)) || (teamLoser.Contains(playerChangeGame.PlayerIdOut) && teamLoser.Contains(playerChangeGame.PlayerIdIn))))
                throw new FormatException("El cambio no es válido.");

            var isValidPlayerOut = _context.PlayersGames.Any(c => c.GameId == playerChangeGame.GameId && c.PlayerId == playerChangeGame.PlayerIdOut) 
                || _context.PlayersChangesGames.Any(c => c.GameId == playerChangeGame.GameId && c.PlayerIdIn == playerChangeGame.PlayerIdOut);

            if (!isValidPlayerOut)
                throw new FormatException("El jugador cambiado no es válido.");


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
            var flag = _context.Games.Any(c => c.GameId == GameId);
            if (!flag)
                throw new FormatException("No se encuentra el juego especificado.");
            return _context.PlayersChangesGames.Where(c => c.GameId == GameId).ToList();

        }

        public List<PlayerChangeGame> GetPlayersChangesInGameLoserTeam(Guid GameId)
        {
            var flag = _context.Games.Any(c => c.GameId == GameId);
            if (!flag)
                throw new FormatException("No se encuentra el juego especificado.");
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            List<Guid> teamLoser = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamId == game.LoserTeamId).Select(d => d.PlayerId).ToList();
            var res = _context.PlayersChangesGames
                .Include(c => c.PlayerPositionIn)
                .Include(c => c.PlayerPositionIn.Player)
                .Include(c => c.PlayerPositionIn.Position)
                .Include(c => c.PlayerPositionOut)
                .Include(c => c.PlayerPositionOut.Player)
                .Include(c => c.PlayerPositionOut.Position)

                .Include(c => c.Game)
                .Where(c => c.GameId == GameId && teamLoser.Contains(c.PlayerIdIn))
                .ToList();
            return res;
        }

        public List<PlayerChangeGame> GetPlayersChangesInGameWinerTeam(Guid GameId)
        {
            var flag = _context.Games.Any(c => c.GameId == GameId);
            if (!flag)
                throw new FormatException("No se encuentra el juego especificado.");
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            List<Guid> teamWiner = _context.TeamsSeriesPlayers.Where(d => d.SerieId == game.SerieId && d.TeamId == game.WinerTeamId).Select(d => d.PlayerId).ToList();
            var res = _context.PlayersChangesGames
                .Include(c => c.PlayerPositionIn)
                .Include(c => c.PlayerPositionIn.Player)
                .Include(c => c.PlayerPositionIn.Position)
                .Include(c => c.PlayerPositionOut)
                .Include(c => c.PlayerPositionOut.Player)
                .Include(c => c.PlayerPositionOut.Position)
                .Include(c => c.Game)
                .Where(c => c.GameId == GameId && teamWiner.Contains(c.PlayerIdIn))
                .ToList();
            return res;
        }

        public bool RemoveChangeInGame(Guid gameId, Guid playerInId, Guid positionIdIn, Guid playerOutId, Guid positionIdOut)
        {
            var currPlayerChange = _context.PlayersChangesGames.SingleOrDefault(c => c.GameId == gameId
            && c.PlayerIdIn == playerInId
            && c.PlayerIdOut == playerOutId
            && c.PositionIdIn == positionIdIn
            && c.PositionIdOut == positionIdOut);
            if (currPlayerChange == null)
                throw new FormatException("No se encuentra el juego especificado es válido.");
            _context.PlayersChangesGames.Remove(currPlayerChange);
            _context.SaveChanges();
            return true;
        }

    }
}
