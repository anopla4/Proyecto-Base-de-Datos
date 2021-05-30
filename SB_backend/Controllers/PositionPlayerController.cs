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
    public class PositionPlayerController : ControllerBase
    {
        private IPositionPlayerRepository _ppRep;
        public PositionPlayerController(IPositionPlayerRepository repo)
        {
            _ppRep = repo;
        }
        [HttpGet]
        public IActionResult GetPositionPlayers()
        {
            return Ok(_ppRep.GetPositionPlayers());
        }

        [HttpGet("{PlayerId}/{PositionId}")]
        public IActionResult GetPositionPlayer(Guid PlayerId, Guid PositionId)
        {
            var player = _ppRep.GetPositionPlayer(PlayerId,PositionId);

            if (player != null)
            {
                return Ok(player);
            }

            return NotFound($"Not position player with id = {PlayerId}{PositionId}");
        }

        [HttpPost]
        public IActionResult AddPositionPlayer(PositionPlayer player)
        {
            _ppRep.AddPositionPlayer(player);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + player.PlayerId + player.PositionId, player);
        }
        [HttpGet("{PlayerId}")]
        public IActionResult GetPlayerPositions(Guid PlayerId)
        {
            var positions = _ppRep.GetPlayerPositions(PlayerId);
            if (positions == null)
                return NotFound($"Not Player with Id {PlayerId}");
            return Ok(positions);
        }
        [HttpDelete("{PlayerId}/{PositionId}")]
        public IActionResult RemovePositionPlayer(Guid PlayerId,Guid PositionId)
        {
            var player = _ppRep.GetPositionPlayer(PlayerId,PositionId);

            if (player != null)
            {
                _ppRep.RemovePositionPlayer(player);
                return Ok();
            }

            return NotFound($"Not position player with id = {PlayerId}{PositionId}");
        }

        [HttpPatch("{PlayerId}/{PositionId}")]
        public IActionResult UpdatePositionPlayer(Guid PlayerId,Guid PositionId, PositionPlayer player)
        {
            var current_player = _ppRep.GetPositionPlayer(PlayerId,PositionId);

            if (current_player != null)
            {
                player.PlayerId = current_player.PlayerId;
                _ppRep.UpdatePositionPlayer(player);
                return Ok(player);
            }

            return NotFound($"Not position player with id = {PlayerId}{PositionId}");
        }
    }
}