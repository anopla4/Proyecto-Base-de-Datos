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
    public class PitcherController : ControllerBase
    {
        private IPitcherRepository _ptRep;
        public PitcherController(IPitcherRepository repo)
        {
            _ptRep = repo;
        }

        [HttpGet]
        public IActionResult GetPitchers()
        {
            return Ok(_ptRep.GetPitchers());
        }

        [HttpGet("{id}")]
        public IActionResult GetPitcher(Guid Id)
        {
            var player = _ptRep.GetPitcher(Id);

            if (player != null)
            {
                return Ok(player);
            }

            return NotFound($"Not pitcher with id = {Id}");
        }

        [HttpPost]
        public IActionResult AddPitcher(Pitcher player)
        {
            _ptRep.AddPitcher(player);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + player.PlayerId, player);
        }

        [HttpDelete("{id}")]
        public IActionResult RemovePitcher(Guid Id)
        {
            var player = _ptRep.GetPitcher(Id);

            if (player != null)
            {
                _ptRep.RemovePitcher(player);
                return Ok();
            }

            return NotFound($"Not position player with id = {Id}");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdatePitcher(Guid Id, Pitcher pitcher)
        {
            var current_player = _ptRep.GetPitcher(Id);

            if (current_player != null)
            {
                pitcher.PlayerId = current_player.PlayerId;
                _ptRep.UpdatePitcher(pitcher);
                return Ok(pitcher);
            }

            return NotFound($"Not pitcher with id = {Id}");
        }
    }
}