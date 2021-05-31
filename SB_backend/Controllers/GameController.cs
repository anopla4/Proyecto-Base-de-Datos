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
    public class GameController : ControllerBase
    {
        private IGameRepository _gRep;
        public GameController(IGameRepository repo)
        {
            _gRep = repo;
        }
        [HttpGet]
        public IActionResult GetGames()
        {
            return Ok(_gRep.GetGames());
        }
        [HttpGet("{SerieId}/{InitDate}/{EndDate}")]
        public IActionResult GetGames(Guid SerieId, DateTime InitDate, DateTime EndDate)
        {
            var games = _gRep.GetGames(SerieId, InitDate, EndDate);
            if (games != null)
                return Ok(games);
            return NotFound($"Not Games In Serie {SerieId}");
        }
        [HttpGet("{Id}")]
        public IActionResult GetGame(Guid Id)
        {
            var game = _gRep.GetGame(Id);
            if (game != null)
                return Ok(game);
            return NotFound($"Not game with Id = {Id}");
        }
        [HttpPost]
        public IActionResult AddGame(Game game)
        {
            var gameA = _gRep.AddGame(game);
            if (gameA == null)
                return BadRequest("Not Added");
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + gameA.GameId, gameA);
        }
        [HttpPatch("{Id}")]
        public IActionResult UpdateGame(Guid Id,Game game)
        {
                var gameU = _gRep.UpdateGame(game);
                if (gameU == null)
                    return NotFound($"Not Game with Id = {Id}");
            return Ok(gameU);
        }
        [HttpDelete("{Id}")]
        public IActionResult RemoveGame(Guid Id, Game game)
        {
            var del = _gRep.RemoveGame(game);
            if (!del)
                return NotFound($"Not Game with Id = {Id}");
            return Ok();
        }
    }
}