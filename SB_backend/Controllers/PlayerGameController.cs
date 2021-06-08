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
    public class PlayerGameController : ControllerBase
    {
        private IPlayerGameRepository _pgRep;
        public PlayerGameController(IPlayerGameRepository repo)
        {
            _pgRep = repo;
        }
        [HttpGet]
        public IActionResult GetPlayersGames()
        {
            return Ok(_pgRep.GetPlayersGames());
        }
        [HttpGet("{GameId}/WinerTeam")]
        public IActionResult GetGamePlayersWinerTeam(Guid GameId)
        {
            try
            {
                var lineup = _pgRep.GetPlayersInGameWinerTeam(GameId);
                return Ok(lineup);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("{GameId}/LoserTeam")]
        public IActionResult GetGamePlayersLoserTeam(Guid GameId)
        {
            try
            {
                var lineup = _pgRep.GetPlayersInGameLoserTeam(GameId);
                return Ok(lineup);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddPlayerInGame(PlayerGame playerGame)
        {
            try
            {
                var playerGameA = _pgRep.AddPlayerInGame(playerGame);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + playerGameA.GameId + "/" + playerGameA.PlayerId, playerGameA);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{GameId}/{PlayerId}/{PositionId}")]
        [Authorize]
        public IActionResult RemovePlayerInGame(Guid GameId, Guid PlayerId,Guid PositionId)
        {
            try
            {
                var playerGame = _pgRep.GetPlayerInGame(GameId, PlayerId, PositionId);
                var playerGameR = _pgRep.DeletePlayerInGame(playerGame);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}