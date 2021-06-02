using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SB_backend.Interfaces;
using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

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
            return Ok(_plrep.GetPlayersWithPositions());
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
            var player = _plrep.GetPlayer(Id);

            if (player != null)
            {
                return Ok(player);
            }

            return NotFound($"Not player with id = {Id} and posId = {PositionId}");
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddPlayer([FromForm]Player player, [FromForm]List<Position> positions)
        {
            this.SaveFile(player);
            Player p = _plrep.AddPlayer(player, positions);
            if (p == null)
                return BadRequest("Not Player Created");
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + player.Id, player);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult RemovePlayer(Guid Id)
        {
            var player = _plrep.GetPlayer(Id);
            var flag = _plrep.RemovePlayer(player);

            if (flag)
            {
                return Ok();
            }

            return NotFound($"Not player with id = {Id}");
        }

        [HttpPatch("{id}")]
        //[Authorize]
        public IActionResult UpdatePlayer(Guid id, [FromForm]Player player, [FromForm]List<Position> positions)
        {
            var current_player = _plrep.GetPlayer(id);

            if (current_player != null)
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), current_player.ImgPath));
                this.SaveFile(player);
                player.Id = current_player.Id;
                _plrep.UpdatePlayer(player, positions);
                return Ok(player);
            }

            return NotFound($"Not player with id = {player.Id}");
        }

        void SaveFile(Player player)
        {
            var file = player.Img;
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                player.ImgPath = dbPath;

            }
        }
    }
}