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
                throw new KeyNotFoundException("No se encuentra el juego especificado.");

            List<PlayerGame> lineup = _context.PlayersGames.Include(c => c.Player).Where(c => c.GameId == GameId).ToList();

            if (lineup.Count == 0)
                throw new Exception("No se han ingresado jugadores al juego especificado.");
            return lineup;
        }

        public List<PlayerPosition> GetPlayersInGameWinerTeam(Guid GameId)
        {
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            if (game == null)
                throw new KeyNotFoundException("No se encuentra el juego especificado.");
            List<PlayerPosition> lineupWT = _context.PlayersGames.Include(c => c.Player)
                 .Where(c => c.GameId == GameId && c.Game.WinerTeamId == game.WinerTeamId)
                 .Select(c => c.Player)
                 .ToList();
            if (lineupWT.Count == 0)
                throw new Exception("No se han ingresado los jugadores del equipo ganador al juego especificado.");
            return lineupWT;
        }

        public List<PlayerPosition> GetPlayersInGameLoserTeam(Guid GameId)
        {
            var game = _context.Games.SingleOrDefault(c => c.GameId == GameId);
            if (game == null)
                throw new KeyNotFoundException("No se encuentra el juego especificado.");
            List<PlayerPosition> lineupWT = _context.PlayersGames.Include(c => c.Player)
                 .Where(c => c.GameId == GameId && c.Game.LoserTeamId == game.LoserTeamId)
                 .Select(c => c.Player)
                 .ToList();
            if (lineupWT.Count == 0)
                throw new Exception("No se han ingresado jugadores al juego especificado.");

            return lineupWT;
        }

        public PlayerGame GetPlayerInGame(Guid gameId, Guid playerId, Guid positionId)
        {
            var plInGame = _context.PlayersGames.SingleOrDefault(c => c.GameId == gameId && c.PlayerId == playerId && c.PositionId == positionId);
            return plInGame;
        }

        public PlayerGame AddPlayerInGame(PlayerGame playerGame)
        {
            Game game = _context.Games.SingleOrDefault(c => c.GameId == playerGame.GameId);
            if (game == null)
                throw new KeyNotFoundException("No se encuentra el juego especificado.");
            bool flagPlayer = _context.TeamsSeriesPlayers.Any(c => c.SerieId == game.SerieId && (c.TeamId == game.WinerTeamId || c.TeamId == game.LoserTeamId) && c.PlayerId == playerGame.PlayerId);
            if (!flagPlayer)
                throw new KeyNotFoundException("No se encuentra el jugador especcificado en este euqipo en la serie correspondiente.");
            bool flagPlayerPosition = _context.PlayerPosition.Any(c => c.PlayerId == playerGame.PlayerId && c.PositionId == playerGame.PositionId);
            if (!flagPlayerPosition)
                throw new KeyNotFoundException("La posición no es válida para este jugador.");
            bool isPositionTaken = _context.PlayersGames.Any(c => c.GameId == playerGame.GameId && c.PositionId == playerGame.PositionId);
            if(isPositionTaken)
                throw new FormatException("Ya existe un jugador en la posición espeificada para el equipo correspondiente al jugador.");
            bool isPlayerAlready = _context.PlayersGames.Any(c => c.GameId == playerGame.GameId && c.PlayerId == playerGame.PlayerId);
            if (isPlayerAlready)
                throw new FormatException("Ya el jugador fue agregado.");

            _context.PlayersGames.Add(playerGame);
            _context.SaveChanges();
            return playerGame;
        }

        public bool DeletePlayerInGame(PlayerGame playerGame)
        {
            var currPlayerGame = _context.PlayersGames.SingleOrDefault(c => c.GameId == playerGame.GameId 
            && c.PlayerId == playerGame.PlayerId 
            && c.PositionId == playerGame.PositionId);
            if (currPlayerGame == null)
                throw new FormatException("No se encuentra el jugador especificado en el juego correspondiente.");

            foreach (var change in _context.PlayersChangesGames.Where(c => c.PlayerIdIn == playerGame.PlayerId || c.PlayerIdOut== playerGame.PlayerId))
                if(!_context.PlayersChangesGames.Any(c => c.PlayerIdIn == playerGame.PlayerId))
                    _context.PlayersChangesGames.Remove(change);
 
            _context.PlayersGames.Remove(currPlayerGame);
            _context.SaveChanges();
            return true;
        }

    }
}
