using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SB_backend.Models;

namespace SB_backend.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> getPlayers();
        Player getPlayer(Guid id);

        Player AddPlayer(Player player);

        bool RemovePlayer(Player player);

        Player UpdatePlayer(Player player);
    }
}
