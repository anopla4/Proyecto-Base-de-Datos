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
        [HttpGet("{PlayerId}/{SerieId}/{InitDate}/{EndDate}")]
        public IActionResult GetTeamSeriePlayer(Guid PlayerId, Guid SerieId, DateTime InitDate, DateTime EndDate)
        {
            var tsp = _tspRep.GetTeamSeriePlayer(SerieId, InitDate, EndDate, PlayerId);
            if (tsp != null)
                return Ok(tsp);
            return NotFound($"Not Player {PlayerId} in Serie {SerieId}");
        }
        [HttpGet("{PlayerId}")]
        public IActionResult GetPlayerTeams(Guid PlayerId)
        {
            var teams = _tspRep.GetPlayerTeams(PlayerId);
            if (teams == null)
                return NotFound($"Not player with Id = {PlayerId}");
            return Ok(teams);
        }
        [HttpGet("Players/{TeamId}/{SerieId}/{InitDate}/{EndDate}")]
        public IActionResult GetPlayersOfTeamInSerie(Guid SerieId, DateTime InitDate, DateTime EndDate, Guid TeamId)
        {
            var players = _tspRep.GetPlayersOfTeamInSerie(TeamId, SerieId, InitDate, EndDate);
            if (players != null)
                return Ok(players);
            return NotFound("Not team {TeamId} in serie {SerieId}");
        }
        [HttpGet("{SerieId}/{InitDate}/{EndDate}")]
        public IActionResult GetPlayersInSerie(Guid SerieId, DateTime InitDate, DateTime EndDate)
        {
            var players = _tspRep.GetPlayersInSerie(SerieId, InitDate, EndDate);
            if (players == null)
                return NotFound($"Not Players in Serie with ID = {SerieId}");
            return Ok(players);
        }
        [HttpGet("{TeamId}")]
        public IActionResult GetTeamPlayers(Guid TeamId)
        {
            var players = _tspRep.GetTeamPlayers(TeamId);
            if (players == null)
                return NotFound($"Not team with Id {TeamId}");
            return Ok(players);
        }
        [HttpGet("{TeamId}/{SerieId}/{InitDate}/{EndDate}/Pitchers")]
        public IActionResult GetPitchersOfTeamInSerie(Guid TeamId, Guid SerieId, DateTime InitDate, DateTime EndDate)
        {
            var pitchers = _tspRep.GetPitchersTeamInSerie(TeamId, SerieId, InitDate, EndDate);
            if (pitchers == null)
                return NotFound("Not Pitchers Found");
            return Ok(pitchers);
        }
        [HttpPost]
        public IActionResult AddTeamSeriePlayer(TeamSeriePlayer tsp)
        {
            var teamSeriePlayerAux = _tspRep.AddTeamSeriePlayer(tsp);
            if (teamSeriePlayerAux == null)
            {
                return NotFound($"PlayerId or SerieId are not valid");
            }
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + tsp.PlayerId + "/" + tsp.SerieId + "/" + tsp.SerieInitDate + "/" + tsp.SerieEndDate, tsp);
        }
        [HttpDelete("{PlayerId}/{SerieId}/{InitDate}/{EndDate}")]
        public IActionResult RemoveTeamSeriePlayer(Guid PlayerId,Guid SerieId, DateTime InitDate, DateTime EndDate, TeamSeriePlayer tsp)
        {
            var tspR = _tspRep.RemoveTeamSeriePlayer(tsp);
            if(tspR)
            {
                return Ok();
            }
            return NotFound($"Not Player {PlayerId} in Serie {SerieId}");
        }
        [HttpPatch("{PlayerId}/{SerieId}/{InitDate}/{EndDate}")]
        public IActionResult UpdateTeamSeriePlayer(Guid PlayerId, Guid SerieId, DateTime InitDate, DateTime EndDate, TeamSeriePlayer tsp)
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