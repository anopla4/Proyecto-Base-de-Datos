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
            var tsd = _tsdRep.GetTeamSerieDirector(teamId, SerieId, initDate, endDate, DirectorId);
            if (tsd != null)
                return Ok(tsd);
            return NotFound($"Not Director {DirectorId} in Serie {SerieId}");
        }
        [HttpGet("Directors/{SerieId}/{initDate}/{endDate}/{TeamId}")]
        public IActionResult GetDirectorsOfTeamInSerie(Guid SerieId, DateTime initDate, DateTime endDate, Guid TeamId)
        {
            var directors = _tsdRep.GetDirectorsOfTeamInSerie(TeamId, SerieId, initDate, endDate);
            if (directors != null)
                return Ok(directors);
            return NotFound("Not team {TeamId} in serie {SerieId}");
        }
        [HttpGet("{TeamId}")]
        public IActionResult GetTeamDirectors(Guid TeamId)
        {
            var directors = _tsdRep.GetTeamDirectors(TeamId);
            if (directors == null)
                return NotFound($"Not team with Id {TeamId}");
            return Ok(directors);
        }
        [HttpPost]
        public IActionResult AddTeamSerieDirector(TeamSerieDirector tsd)
        {
            var teamSerieDirectorAux = _tsdRep.AddTeamSerieDirector(tsd);
            if (teamSerieDirectorAux == null)
            {
                return NotFound($"DirectorId or SerieId are not valid");
            }
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + tsd.DirectorId + tsd.SerieId, tsd);
        }
        [HttpDelete("{DirectorId}/{SerieId}/{initDate}/{endDate}/{teamId}")]
        public IActionResult RemoveTeamSerieDirector(Guid DirectorId, Guid SerieId, DateTime initDate, DateTime endDate, Guid teamId)
        {
            TeamSerieDirector tsd = _tsdRep.GetTeamSerieDirector(teamId, SerieId, initDate, endDate, DirectorId);

            var tsdR = _tsdRep.RemoveTeamSerieDirector(tsd);
            if (tsdR)
            {
                return Ok();
            }
            return NotFound($"Not Director {DirectorId} in Serie {SerieId}");
        }
        [HttpPatch("{DirectorId}/{SerieId}/{initDate}/{endDate}/{teamId}")]
        public IActionResult UpdateTeamSerieDirector(Guid DirectorId, Guid SerieId, DateTime initDate, DateTime endDate, Guid teamId, TeamSerieDirector tsd)
        {
            tsd.DirectorId = DirectorId;
            tsd.SerieId = SerieId;
            tsd.SerieInitDate = initDate;
            tsd.SerieEndDate = endDate;
            tsd.TeamSerieId = teamId;
            var tsdUpd = _tsdRep.UpdateTeamSerieDirector(tsd);
            if (tsdUpd != null)
            {
                return Ok(tsdUpd);
            }
            return NotFound($"Not Director {DirectorId} in Serie {SerieId}");
        }
    }
}