using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface IGameRepository
    {
        List<Game> GetGames();
        Game GetGame(Guid Id);
        List<Game> GetGames(Guid SerieId);
        Game AddGame(Game game);
        Game UpdateGame(Game game);
        bool RemoveGame(Game game);
    }
}
