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
    public class TeamSerieController : ControllerBase
    {
        private ITeamSerieRepository _tsRep;
        public TeamSerieController(ITeamSerieRepository repo)
        {
            _tsRep = repo;
        }
        [HttpGet]
        public IActionResult GetTeamsSeries()
        {
            return Ok(_tsRep.GetTeamsSeries());
        }
        [HttpGet("Standing/{SerieId}/{initDate}/{endDate}")]
        public IActionResult GetStanding(Guid SerieId, DateTime initDate, DateTime endDate)
        {
            List<TeamSerie> serie = _tsRep.GetStanding(SerieId, initDate, endDate);
            if (serie.Count == 0)
            {
                return NotFound($"Not Standing to serie {SerieId}");
            }
            return Ok(serie);
        }
        [HttpGet("{TeamId}/{SerieId}/{initDate}/{endDate}")]
        public IActionResult GetTeamSerie(Guid TeamId, Guid SerieId, DateTime initDate, DateTime endDate)
        {
            TeamSerie teamSerie = _tsRep.GetTeamSerie(TeamId, SerieId, initDate, endDate);
            if (teamSerie == null)
            {
                return NotFound($"Not TeamSerie with ids = {TeamId},{SerieId},{initDate},{endDate}");
            }
            return Ok(teamSerie);
        }
        [HttpGet("TeamWonSeries/{TeamId}")]
        public IActionResult GetTeamWonSeries(Guid TeamId)
        {
            var series = _tsRep.GetTeamWonSeries(TeamId);
            if (series == null)
            {
                return NotFound($"Not Team in TeamsSeries with Id = {TeamId}");
            }
            return Ok(series);
        }
        [HttpPost]
        public IActionResult AddTeamSerie(TeamSerie teamSerie)
        {
            var teamSerieAux = _tsRep.AddTeamSerie(teamSerie);
            if (teamSerieAux == null)
            {
                return NotFound($"TeamId or SerieId are not valid");
            }
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + teamSerie.TeamId + "/" +teamSerie.SerieId + "/" + teamSerie.SerieInitDate + "/" + teamSerie.SerieEndDate, teamSerie);
        }
        [HttpDelete("{TeamId}/{SerieId}/{initDate}/{endDate}")]
        public IActionResult RemoveTeamSerie(Guid TeamId,Guid SerieID, DateTime initDate, DateTime endTime, TeamSerie teamSerie)
        {
            var flag = _tsRep.RemoveTeamSerie(teamSerie);
            if (flag)
            {
                return Ok();
            }
            return NotFound($"Not valid TeamSerie");
        }
        [HttpPatch("{TeamId}/{SerieId}/{initDate}/{endDate}")]
        public IActionResult UpdateTeamSerie(Guid TeamId,Guid SerieId,DateTime initDate, DateTime endDate,TeamSerie teamSerie)
        {
            var teamSerieUpd = _tsRep.UpdateTeamSerie(teamSerie);
            if(teamSerieUpd == null)
            {
                return NotFound($"Not TeamSerie with ids = {TeamId},{SerieId},{initDate},{endDate}");
            }
            return Ok(teamSerieUpd);
        }

    }
}