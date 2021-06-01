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
            var lineup = _pgRep.GetPlayersInGameWinerTeam(GameId);
            if (lineup == null)
                return NotFound($"Not Lineup in Game {GameId}");
            return Ok(lineup);
        }
        [HttpGet("{GameId}/LoserTeam")]
        public IActionResult GetGamePlayersLoserTeam(Guid GameId)
        {
            var lineup = _pgRep.GetPlayersInGameLoserTeam(GameId);
            if (lineup == null)
                return NotFound($"Not Lineup in Game {GameId}");
            return Ok(lineup);
        }
        [HttpPost]
        public IActionResult AddPlayerInGame(PlayerGame playerGame)
        {
            var playerGameA = _pgRep.AddPlayerInGame(playerGame);
            if (playerGameA == null)
                return BadRequest("Not created object");
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + playerGameA.GameId + "/" + playerGameA.PlayerId, playerGameA);
        }
        [HttpDelete("{GameId}/{PlayerId}/{PositionId}")]
        public IActionResult RemovePlayerInGame(Guid GameId, Guid PlayerId,Guid PositionId)
        {
            var playerGame = _pgRep.GetPlayerInGame(GameId, PlayerId,PositionId);
            var playerGameR = _pgRep.DeletePlayerInGame(playerGame);
            if (!playerGameR)
                return NotFound("Object Not Found");
            return Ok();
        }
    }
}