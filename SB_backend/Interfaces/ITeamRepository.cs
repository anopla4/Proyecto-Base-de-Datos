using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    public interface ITeamRepository
    {
        List<Team> getTeams();
        Team getTeam(Guid Id);
        Team UpdateTeam(Team team);
        Team AddTeam(Team team);
        bool RemoveTeam(Team team);
    }
}
