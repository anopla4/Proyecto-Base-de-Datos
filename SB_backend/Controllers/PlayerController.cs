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
            try
            {
                var positions = _plrep.GetPlayerPositions(playerId);
                return Ok(positions);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("Pitchers")]
        public IActionResult GetPitchers()
        {
            try
            {
                var pitchers = _plrep.GetPitchers();
                return Ok(pitchers);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("{id}/{PositionId}")]
        public IActionResult GetPlayer(Guid Id, Guid PositionId)
        {
            try
            {
                var player = _plrep.GetPlayer(Id);
                return Ok(player);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddPlayer([FromForm]Player player, [FromForm]List<Position> positions)
        {
            try
            {
                this.SaveFile(player);
                Player p = _plrep.AddPlayer(player, positions);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + player.Id, player);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult RemovePlayer(Guid Id)
        {
            try
            {
                var player = _plrep.GetPlayer(Id);
                var flag = _plrep.RemovePlayer(player);
                return Ok();   
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPatch("{id}")]
        [Authorize]
        public IActionResult UpdatePlayer(Guid id, [FromForm]Player player, [FromForm]List<Position> positions)
        {
            try
            {
                var current_player = _plrep.GetPlayer(id);

                if (player.Img != null)
                    {
                        if (current_player.ImgPath != null)
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), current_player.ImgPath));
                        this.SaveFile(player);
                    }

                player.Id = current_player.Id;
                _plrep.UpdatePlayer(player, positions);
                return Ok(player);
                
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
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