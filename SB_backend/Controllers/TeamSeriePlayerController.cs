using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
            try
            {
                var tsp = _tspRep.GetTeamSeriePlayer(SerieId, InitDate, EndDate, PlayerId);
                return Ok(tsp);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("{PlayerId}")]
        public IActionResult GetPlayerTeams(Guid PlayerId)
        {
            try
            {
                var teams = _tspRep.GetPlayerTeams(PlayerId);
                return Ok(teams);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("Players/{TeamId}/{SerieId}/{InitDate}/{EndDate}")]
        public IActionResult GetPlayersOfTeamInSerie(Guid SerieId, DateTime InitDate, DateTime EndDate, Guid TeamId)
        {
            try
            {
                var players = _tspRep.GetPlayersOfTeamInSerie(TeamId, SerieId, InitDate, EndDate);
                return Ok(players);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("{SerieId}/{InitDate}/{EndDate}")]
        public IActionResult GetPlayersInSerie(Guid SerieId, DateTime InitDate, DateTime EndDate)
        {
            try
            {
                var players = _tspRep.GetPlayersInSerie(SerieId, InitDate, EndDate);
                return Ok(players);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("Team/{TeamId}")]
        public IActionResult GetTeamPlayers(Guid TeamId)
        {
            try
            {
                var players = _tspRep.GetTeamPlayers(TeamId);
                return Ok(players);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("{TeamId}/{SerieId}/{InitDate}/{EndDate}/Pitchers")]
        public IActionResult GetPitchersOfTeamInSerie(Guid TeamId, Guid SerieId, DateTime InitDate, DateTime EndDate)
        {
            try
            {
                var pitchers = _tspRep.GetPitchersTeamInSerie(TeamId, SerieId, InitDate, EndDate);
                return Ok(pitchers);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddTeamSeriePlayer(TeamSeriePlayer tsp)
        {
            try
            {
                var teamSeriePlayerAux = _tspRep.AddTeamSeriePlayer(tsp);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + tsp.PlayerId + "/" + tsp.SerieId + "/" + tsp.SerieInitDate + "/" + tsp.SerieEndDate, tsp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{PlayerId}/{SerieId}/{InitDate}/{EndDate}")]
        [Authorize]
        public IActionResult RemoveTeamSeriePlayer(Guid PlayerId,Guid SerieId, DateTime InitDate, DateTime EndDate)
        {
            try
            {
                var tspR = _tspRep.GetTeamSeriePlayer(SerieId, InitDate, EndDate, PlayerId);
                var deleted = _tspRep.RemoveTeamSeriePlayer(tspR);
                return Ok();
                
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPatch("{PlayerId}/{SerieId}/{InitDate}/{EndDate}")]
        [Authorize]
        public IActionResult UpdateTeamSeriePlayer(Guid PlayerId, Guid SerieId, DateTime InitDate, DateTime EndDate, TeamSeriePlayer tsp)
        {
            try
            {
                var tspUpd = _tspRep.UpdateTeamSeriePlayer(tsp);
                return Ok(tspUpd);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}