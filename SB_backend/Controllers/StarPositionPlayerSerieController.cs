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
    public class StarPositionPlayerSerieController : ControllerBase
    {
        private IStarPositionPlayerSerieRepository _spRep;
        public StarPositionPlayerSerieController(IStarPositionPlayerSerieRepository repo)
        {
            _spRep = repo;
        }

        [HttpGet]
        public IActionResult GetAllStarsTeamsSeries()
        {
            return Ok(_spRep.GetStarPositionPlayersSeries());
        }
        [HttpGet("{SerieId}/{InitDate}/{EndDate}")]
        public IActionResult GetAllStarTeamSerie(Guid SerieId, DateTime InitDate, DateTime EndDate)
        {
            var allStartTeam = _spRep.GetAllStarsTeam(SerieId, InitDate, EndDate);
            if (allStartTeam != null)
                return Ok(allStartTeam);
            return NotFound($"Not AllStarTeam for Serie with Id = {SerieId}");
        }
        [HttpPost]
        public IActionResult AddStarPositionPlayerSerie(StarPositionPlayerSerie starPositionPlayerSerie)
        {
            var startPPS = _spRep.AddStarPositionPlayerSerie(starPositionPlayerSerie);
            if(startPPS != null)
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + startPPS.SerieId + "/" + startPPS.SerieInitDate + "/" + startPPS.SerieEndDate + "/" + startPPS.PositionId, startPPS);
            return BadRequest($"Not added StartPositionPlayer");
        }
        [HttpGet("{SerieId}/{InitDate}/{EndDate}/{PositionId}")]
        public IActionResult GetStarPlayerOfPositionInSerie(Guid SerieId, DateTime InitDate, DateTime EndDate, Guid PositionId)
        {
            var player = _spRep.GetStarPositionPlayerSerie(SerieId,InitDate,EndDate, PositionId);
            if (player != null)
                return Ok(player);
            return NotFound($"Not Player in AllStartTeam Of Serie {SerieId} in position {PositionId}");
        }
        [HttpPatch("{SerieId}/{InitDate}/{EndDate}/{PositionId}")]
        public IActionResult UpdateStarTeamSerie(Guid SerieId, DateTime InitDate, DateTime EndDate,Guid PositionId,StarPositionPlayerSerie starPositionPlayerSerie)
        {
            var player = _spRep.UpdateStarPositionPlayerSerie(starPositionPlayerSerie);
            if (player != null)
                return Ok(player);
            return NotFound($"Not Player in AllStartTeam Of Serie {SerieId} in position {PositionId}");
        }

        [HttpDelete("{SerieId}/{InitDate}/{EndDate}/{PositionId}")]
        public IActionResult RemoveStarPositionPlayerSerie(Guid SerieId, DateTime InitDate, DateTime EndDate, Guid PositionId, StarPositionPlayerSerie starPositionPlayerSerie)
        {
            var flag = _spRep.RemoveStarPositionPlayer(starPositionPlayerSerie);
            if (flag)
                return Ok();
            return NotFound($"Object Not Found");
        }
    }
}