using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface IPitcherRepository
    {
        List<Pitcher> GetPitchers();
        Pitcher GetPitcher(Guid Id);
        Pitcher AddPitcher(Pitcher pitcher);
        Pitcher UpdatePitcher(Pitcher pitcher);
        bool RemovePitcher(Pitcher pitcher);
    }
}
