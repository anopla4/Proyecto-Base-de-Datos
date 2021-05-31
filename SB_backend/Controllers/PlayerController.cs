using Microsoft.AspNetCore.Mvc;
using SB_backend.Interfaces;
using SB_backend.Models;
using System;
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
        [HttpGet("{id}")]
        public IActionResult GetPlayer(Guid Id)
        {
            var player = _plrep.GetPlayer(Id);

            if (player != null)
            {
                return Ok(player);
            }

            return NotFound($"Not player with id = {Id}");
        }

        [HttpPost]
        public IActionResult AddPlayer([FromForm]Player player)
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
            _plrep.AddPlayer(player);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + player.Id, player);
        }

        [HttpDelete("{id}")]
        public IActionResult RemovePlayer(Guid Id, Player player)
        {
            var flag = _plrep.RemovePlayer(player);

            if (flag)
            {
                return Ok();
            }

            return NotFound($"Not player with id = {Id}");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePlayer(Guid Id, Player player)
        {
            var current_player = _plrep.GetPlayer(Id);

            if (current_player != null)
            {
                player.Id = current_player.Id;
                _plrep.UpdatePlayer(player);
                return Ok(player);
            }

            return NotFound($"Not player with id = {Id}");
        }
    }
}