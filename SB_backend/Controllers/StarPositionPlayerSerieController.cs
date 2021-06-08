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
            try
            {
                var allStartTeam = _spRep.GetAllStarsTeam(SerieId, InitDate, EndDate);
                return Ok(allStartTeam);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddStarPositionPlayerSerie(StarPositionPlayerSerie starPositionPlayerSerie)
        {
            try
            {
                var startPPS = _spRep.AddStarPositionPlayerSerie(starPositionPlayerSerie);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + startPPS.SerieId + "/" + startPPS.SerieInitDate + "/" + startPPS.SerieEndDate + "/" + startPPS.PositionId, startPPS);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("{SerieId}/{InitDate}/{EndDate}/{PositionId}")]
        [Authorize]
        public IActionResult GetStarPlayerOfPositionInSerie(Guid SerieId, DateTime InitDate, DateTime EndDate, Guid PositionId)
        {
            try
            {
                var player = _spRep.GetStarPositionPlayerSerie(SerieId, InitDate, EndDate, PositionId);
                return Ok(player);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPatch("{SerieId}/{InitDate}/{EndDate}/{PositionId}")]
        [Authorize]
        public IActionResult UpdateStarTeamSerie(Guid SerieId, DateTime InitDate, DateTime EndDate,Guid PositionId,StarPositionPlayerSerie starPositionPlayerSerie)
        {
            try
            {
                var player = _spRep.UpdateStarPositionPlayerSerie(starPositionPlayerSerie);
                return Ok(player);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{SerieId}/{InitDate}/{EndDate}/{PositionId}")]
        [Authorize]
        public IActionResult RemoveStarPositionPlayerSerie(Guid SerieId, DateTime InitDate, DateTime EndDate, Guid PositionId, StarPositionPlayerSerie starPositionPlayerSerie)
        {
            try
            {
                var flag = _spRep.RemoveStarPositionPlayer(starPositionPlayerSerie);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}