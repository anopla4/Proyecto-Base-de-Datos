using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SB_backend.Interfaces;
using SB_backend.Models;

namespace SB_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamSeriePlayerController : ControllerBase
    {
        private ITeamSeriePlayerRepository _tspRep;
        public TeamSeriePlayerController(ITeamSeriePlayerRepository repo)
        {
            _tspRep = repo;
        }
        [HttpGet]
        public IActionResult GetTeamsSeriesPlayers()
        {
            return Ok(_tspRep.GetTeamsSeriesPlayers());
        }
        [HttpGet("{PlayerId}/{SerieId}")]
        public IActionResult GetTeamSeriePlayer(Guid PlayerId, Guid SerieId)
        {
            var tsp = _tspRep.GetTeamSeriePlayer(SerieId, PlayerId);
            if (tsp != null)
                return Ok(tsp);
            return NotFound($"Not Player {PlayerId} in Serie {SerieId}");
        }
        [HttpGet("Players/{SerieId}/{TeamId}")]
        public IActionResult GetPlayersOfTeamInSerie(Guid SerieId,Guid TeamId)
        {
            var players = _tspRep.GetPlayersOfTeamInSerie(TeamId, SerieId);
            if (players != null)
                return Ok(players);
            return NotFound("Not team {TeamId} in serie {SerieId}");
        }
        [HttpGet("{TeamId}")]
        public IActionResult GetTeamPlayers(Guid TeamId)
        {
            var players = _tspRep.GetTeamPlayers(TeamId);
            if (players == null)
                return NotFound($"Not team with Id {TeamId}");
            return Ok(players);
        }
        [HttpPost]
        public IActionResult AddTeamSeriePlayer(TeamSeriePlayer tsp)
        {
            var teamSeriePlayerAux = _tspRep.AddTeamSeriePlayer(tsp);
            if (teamSeriePlayerAux == null)
            {
                return NotFound($"PlayerId or SerieId are not valid");
            }
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + tsp.PlayerId + tsp.SerieId, tsp);
        }
        [HttpDelete("{PlayerId}/{SerieId}")]
        public IActionResult RemoveTeamSeriePlayer(Guid PlayerId,Guid SerieId,TeamSeriePlayer tsp)
        {
            var tspR = _tspRep.RemoveTeamSeriePlayer(tsp);
            if(tspR)
            {
                return Ok();
            }
            return NotFound($"Not Player {PlayerId} in Serie {SerieId}");
        }
        [HttpPatch("{PlayerId}/{SerieId}")]
        public IActionResult UpdateTeamSeriePlayer(Guid PlayerId, Guid SerieId, TeamSeriePlayer tsp)
        {
            var tspUpd = _tspRep.UpdateTeamSeriePlayer(tsp);
            if (tspUpd != null)
            {
                return Ok(tspUpd);
            }
            return NotFound($"Not Player {PlayerId} in Serie {SerieId}");
        }
    }
}