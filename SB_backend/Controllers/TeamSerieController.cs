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
            try
            {
                List<TeamSerie> serie = _tsRep.GetStanding(SerieId, initDate, endDate);
                return Ok(serie);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("{TeamId}/{SerieId}/{initDate}/{endDate}")]
        public IActionResult GetTeamSerie(Guid TeamId, Guid SerieId, DateTime initDate, DateTime endDate)
        {
            try
            {
                TeamSerie teamSerie = _tsRep.GetTeamSerie(TeamId, SerieId, initDate, endDate);
                return Ok(teamSerie);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("TeamWonSeries/{TeamId}")]
        public IActionResult GetTeamWonSeries(Guid TeamId)
        {
            try
            {
                var series = _tsRep.GetTeamWonSeries(TeamId);
                return Ok(series);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddTeamSerie(TeamSerie teamSerie)
        {
            try
            {
                var teamSerieAux = _tsRep.AddTeamSerie(teamSerie);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + teamSerie.TeamId + "/" + teamSerie.SerieId + "/" + teamSerie.SerieInitDate + "/" + teamSerie.SerieEndDate, teamSerie);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{TeamId}/{SerieId}/{initDate}/{endDate}")]
        [Authorize]
        public IActionResult RemoveTeamSerie(Guid TeamId, Guid SerieId, DateTime initDate, DateTime endDate)
        {
            try
            {
                TeamSerie teamSerie = _tsRep.GetTeamSerie(TeamId, SerieId, initDate, endDate);

                var flag = _tsRep.RemoveTeamSerie(teamSerie);
                return Ok();
                
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPatch("{TeamId}/{SerieId}/{initDate}/{endDate}")]
        [Authorize]
        public IActionResult UpdateTeamSerie(Guid TeamId,Guid SerieId,DateTime initDate, DateTime endDate,TeamSerie teamSerie)
        {
            try
            {
                teamSerie.TeamId = TeamId;
                teamSerie.SerieId = SerieId;
                teamSerie.SerieInitDate = initDate;
                teamSerie.SerieEndDate = endDate;
                var teamSerieUpd = _tsRep.UpdateTeamSerie(teamSerie);
                return Ok(teamSerieUpd);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}