using Microsoft.AspNetCore.Mvc;
using SB_backend.Interfaces;
using SB_backend.Models;
using System;

namespace SB_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IPlayerRepository _plrep;
        public PlayerController(IPlayerRepository repo)
        {
            _plrep = repo;
        }

        [HttpGet]
        public IActionResult GetPlayers()
        {
            return Ok(_plrep.GetPlayers());
        }
        [HttpGet("{playerId}/Positions")]
        public IActionResult GetPlayerPositions(Guid playerId)
        {
            var positions = _plrep.GetPlayerPositions(playerId);
            if (positions == null)
                return NotFound($"Not Player with Id = {playerId}");
            return Ok(positions);
        }
        [HttpGet("Pitchers")]
        public IActionResult GetPitchers()
        {
            var pitchers = _plrep.GetPitchers();
            return Ok(pitchers);
        }
        [HttpGet("{id}/{PositionId}")]
        public IActionResult GetPlayer(Guid Id, Guid PositionId)
        {
            var player = _plrep.GetPlayer(Id,PositionId);

            if (player != null)
            {
                return Ok(player);
            }

            return NotFound($"Not player with id = {Id} and posId = {PositionId}");
        }

        [HttpPost]
        public IActionResult AddPlayer(Player player)
        {
            _plrep.AddPlayer(player);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + player.Id + "/" + player.PositionId, player);
        }

        [HttpDelete("{id}/{PositionId}")]
        public IActionResult RemovePlayer(Guid Id, Guid PositionId,Player player)
        {
            var flag = _plrep.RemovePlayer(player);

            if (flag)
            {
                return Ok();
            }

            return NotFound($"Not player with id = {Id} and posId = {PositionId}");
        }

        [HttpPatch("{id}/{PositionId}")]
        public IActionResult UpdatePlayer(Guid Id, Guid PositionId,Player player)
        {
            var current_player = _plrep.GetPlayer(Id,PositionId);

            if (current_player != null)
            {
                player.Id = current_player.Id;
                player.PositionId = current_player.PositionId;
                _plrep.UpdatePlayer(player);
                return Ok(player);
            }

            return NotFound($"Not player with id = {Id} and posId = {PositionId}");
        }
    }
}