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
    public class PlayerChangeGameController : ControllerBase
    {
        private IPlayerChangeGameRepository _pchRep;
        public PlayerChangeGameController(IPlayerChangeGameRepository repo)
        {
            _pchRep = repo;
        }
        [HttpGet("{GameID}/WinerTeam")]    
        public IActionResult GetGameChangesWinerTeam(Guid GameId)
        {
            try
            {
                var changes = _pchRep.GetPlayersChangesInGameWinerTeam(GameId);
                return Ok(changes);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("{GameID}/LoserTeam")]
        public IActionResult GetGameChangesLoserTeam(Guid GameId)
        {
            try
            {
                var changes = _pchRep.GetPlayersChangesInGameLoserTeam(GameId);
                return Ok(changes);
            }
            catch (Exception e) 
            { 
                return NotFound(e.Message); 
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddChange(PlayerChangeGame change)
        {
            try
            {
                var changeA = _pchRep.AddChangeInGame(change);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + change.GameId + "/" + change.PlayerIdIn + "/" + change.PositionIdIn, change);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{GameId}/{PlayerInId}/{PositionIdIn}/{PlayerOutId}/{PositionIdOut}/")]
        [Authorize]
        public IActionResult RemoveChange(Guid GameId, Guid PlayerInId, Guid PositionIdIn, Guid PlayerOutId, Guid PositionIdOut)
        {
            try
            {
                var rem = _pchRep.RemoveChangeInGame(GameId, PlayerInId, PositionIdIn, PlayerOutId, PositionIdOut);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}