using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SB_backend.Interfaces;
using SB_backend.Models;

namespace SB_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private IPositionRepository _posRep;
        public PositionController(IPositionRepository repo)
        {
            _posRep = repo;
        }

        [HttpGet]
        public IActionResult GetPositions()
        {
            return Ok(_posRep.GetPositions());
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddPosition(Position position)
        {
            try
            {
                _posRep.AddPosition(position);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + position.Id, position);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public IActionResult RemovePosition(Guid Id)
        {
            try
            {
                var position = _posRep.GetPosition(Id);
                _posRep.RemovePosition(position);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPatch("{id}")]
        [Authorize]
        public IActionResult UpdateCaracter(Guid Id, Position position)
        {
            try
            {
                var current_position = _posRep.GetPosition(Id);
                position.Id = current_position.Id;
                _posRep.UpdatePosition(position);
                return Ok(position);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}