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
    public class StartPositionPlayerSerieController : ControllerBase
    {
        private IStartPositionPlayerSerieRepository _spRep;
        public StartPositionPlayerSerieController(IStartPositionPlayerSerieRepository repo)
        {
            _spRep = repo;
        }

        [HttpGet]
        public IActionResult GetAllStartsTeamsSeries()
        {
            return Ok(_spRep.GetStartPositionPlayersSeries());
        }
        [HttpGet("{SerieId}")]
        public IActionResult GetAllStartTeamSerie(Guid SerieId)
        {
            var allStartTeam = _spRep.GetAllStartsTeam(SerieId);
            if (allStartTeam != null)
                return Ok(allStartTeam);
            return NotFound($"Not AllStarTeam for Serie with Id = {SerieId}");
        }
        [HttpPost]
        public IActionResult AddStartPositionPlayerSerie(Guid SerieId, Guid PositionId,StartPositionPlayerSerie startPositionPlayerSerie)
        {
            var startPPS = _spRep.AddStartPositionPlayerSerie(startPositionPlayerSerie);
            if(startPPS != null)
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + startPPS.SerieId + startPPS.PositionId, startPPS);
            return BadRequest($"Not added StartPositionPlayer");
        }
        [HttpGet("{SerieId},{PositionId}")]
        public IActionResult GetStartPlayerOfPositionInSerie(Guid SerieId,Guid PositionId)
        {
            var player = _spRep.GetStartPositionPlayerSerie(SerieId, PositionId);
            if (player != null)
                return Ok(player);
            return NotFound($"Not Player in AllStartTeam Of Serie {SerieId} in position {PositionId}");
        }
        [HttpPatch("{SerieId}{PositionId}")]
        public IActionResult UpdateStartTeamSerie(Guid SerieId,Guid PositionId,StartPositionPlayerSerie startPositionPlayerSerie)
        {
            var player = _spRep.UpdateStartPositionPlayerSerie(startPositionPlayerSerie);
            if (player != null)
                return Ok(player);
            return NotFound($"Not Player in AllStartTeam Of Serie {SerieId} in position {PositionId}");
        }

        [HttpDelete("{SerieId}{PositionId}")]
        public IActionResult RemoveStartPositionPlayerSerie(Guid SerieId, Guid PositionId, StartPositionPlayerSerie startPositionPlayerSerie)
        {
            var flag = _spRep.RemoveStartPositionPlayer(startPositionPlayerSerie);
            if (flag)
                return Ok();
            return NotFound($"Object Not Found");
        }
    }
}