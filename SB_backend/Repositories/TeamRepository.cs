using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private AppDBContext _teamContext;

        public TeamRepository(AppDBContext teamContext)
        {
            _teamContext = teamContext;
        }
        public Team AddTeam(Team team)
        {
            team.Id = Guid.NewGuid();
            _teamContext.Teams.Add(team);
            _teamContext.SaveChanges();
            return team;
        }

        public List<Team> getTeams()
        {
            return _teamContext.Teams.ToList();
        }
        public Team getTeam(Guid Id)
        {
            var team = _teamContext.Teams.Find(Id);
            return team;
        }

        public bool RemoveTeam(Team team)
        {
            var curr_team = _teamContext.Teams.Find(team.Id);

            if (curr_team != null)
            {
                _teamContext.Teams.Remove(curr_team);
                _teamContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Team UpdateTeam(Team team)
        {
            var curr_team = _teamContext.Teams.Find(team.Id);

            if (curr_team != null)
            {
                curr_team.Color = team.Color;
                curr_team.Initials = team.Initials;
                curr_team.Name = team.Name;
                _teamContext.Teams.Update(curr_team);
                _teamContext.SaveChanges();
            }
            return team;
        }
    }
}
