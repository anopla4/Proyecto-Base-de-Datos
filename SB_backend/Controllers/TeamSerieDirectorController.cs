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
    public class TeamSerieDirectorController : ControllerBase
    {
        private ITeamSerieDirectorRepository _tsdRep;
        public TeamSerieDirectorController(ITeamSerieDirectorRepository repo)
        {
            _tsdRep = repo;
        }
        [HttpGet]
        public IActionResult GetTeamsSeriesDirectors()
        {
            return Ok(_tsdRep.GetTeamsSeriesDirectors());
        }
        [HttpGet("{DirectorId}/{SerieId}/{initDate}/{endDate}/{teamId}")]
        public IActionResult GetTeamSerieDirector(Guid DirectorId, Guid SerieId, DateTime initDate, Guid teamId, DateTime endDate)
        {
            try
            {
                var tsd = _tsdRep.GetTeamSerieDirector(teamId, SerieId, initDate, endDate, DirectorId);
                return Ok(tsd);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("Directors/{SerieId}/{initDate}/{endDate}/{TeamId}")]
        public IActionResult GetDirectorsOfTeamInSerie(Guid SerieId, DateTime initDate, DateTime endDate, Guid TeamId)
        {
            try
            {
                var directors = _tsdRep.GetDirectorsOfTeamInSerie(TeamId, SerieId, initDate, endDate);
                return Ok(directors);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("{TeamId}")]
        public IActionResult GetTeamDirectors(Guid TeamId)
        {
            try
            {
                var directors = _tsdRep.GetTeamDirectors(TeamId);
                return Ok(directors);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddTeamSerieDirector(TeamSerieDirector tsd)
        {
            try
            {
                var teamSerieDirectorAux = _tsdRep.AddTeamSerieDirector(tsd);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + tsd.DirectorId + tsd.SerieId, tsd);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{DirectorId}/{SerieId}/{initDate}/{endDate}/{teamId}")]
        [Authorize]
        public IActionResult RemoveTeamSerieDirector(Guid DirectorId, Guid SerieId, DateTime initDate, DateTime endDate, Guid teamId)
        {
            try
            {
                TeamSerieDirector tsd = _tsdRep.GetTeamSerieDirector(teamId, SerieId, initDate, endDate, DirectorId);

                var tsdR = _tsdRep.RemoveTeamSerieDirector(tsd);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPatch("{DirectorId}/{SerieId}/{initDate}/{endDate}/{teamId}")]
        [Authorize]
        public IActionResult UpdateTeamSerieDirector(Guid DirectorId, Guid SerieId, DateTime initDate, DateTime endDate, Guid teamId, TeamSerieDirector tsd)
        {
            try
            {
                tsd.DirectorId = DirectorId;
                tsd.SerieId = SerieId;
                tsd.SerieInitDate = initDate;
                tsd.SerieEndDate = endDate;
                tsd.TeamSerieId = teamId;
                var tsdUpd = _tsdRep.UpdateTeamSerieDirector(tsd);
                return Ok(tsdUpd);
                
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}