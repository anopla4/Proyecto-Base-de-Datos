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

        [HttpGet("{id}")]
        public IActionResult GetPositionPlayer(Guid Id)
        {
            var player = _ppRep.GetPositionPlayer(Id);

            if (player != null)
            {
                return Ok(player);
            }

            return NotFound($"Not position player with id = {Id}");
        }

        [HttpPost]
        public IActionResult AddPositionPlayer(PositionPlayer player)
        {
            _ppRep.AddPositionPlayer(player);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + player.PlayerId, player);
        }

        [HttpDelete("{id}")]
        public IActionResult RemovePositionPlayer(Guid Id)
        {
            var player = _ppRep.GetPositionPlayer(Id);

            if (player != null)
            {
                _ppRep.RemovePositionPlayer(player);
                return Ok();
            }

            return NotFound($"Not position player with id = {Id}");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePositionPlayer(Guid Id, PositionPlayer player)
        {
            var current_player = _ppRep.GetPositionPlayer(Id);

            if (current_player != null)
            {
                player.PlayerId = current_player.PlayerId;
                _ppRep.UpdatePositionPlayer(player);
                return Ok(player);
            }

            return NotFound($"Not position player with id = {Id}");
        }
    }
}