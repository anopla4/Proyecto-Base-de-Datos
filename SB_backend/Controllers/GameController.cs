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
            try
            {
                var games = _gRep.GetGames(SerieId, InitDate, EndDate);
                return Ok(games);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }
        [HttpGet("{Id}")]
        public IActionResult GetGame(Guid Id)
        {
            try
            {
                var game = _gRep.GetGame(Id);
                return Ok(game);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddGame(Game game)
        {
            try
            {
                var gameA = _gRep.AddGame(game);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + gameA.GameId, gameA);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPatch("{Id}")]
        [Authorize]
        public IActionResult UpdateGame(Guid Id,Game game)
        {
            try
            {
                var gameU = _gRep.UpdateGame(game);
                return Ok(gameU);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete("{Id}")]
        [Authorize]
        public IActionResult RemoveGame(Guid Id, Game game)
        {
            try
            {
                var del = _gRep.RemoveGame(game);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}