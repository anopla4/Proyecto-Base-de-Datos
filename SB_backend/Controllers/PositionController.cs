using System;
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
        [HttpGet("{Position_Name}")]
        public IActionResult GetPosition(string Position_Name)
        {
            var position = _posRep.GetPosition(Position_Name);

            if (position != null)
            {
                return Ok(position);
            }

            return NotFound($"Not position with name = {Position_Name}");
        }

        [HttpPost]
        public IActionResult AddPosition(Position position)
        {
            _posRep.AddPosition(position);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + position.Position_Name,position);
        }

        [HttpDelete("{Position_Name}")]
        public IActionResult RemovePosition(string Position_name)
        {
            var position = _posRep.GetPosition(Position_name);

            if (position != null)
            {
                _posRep.RemovePosition(position);
                return Ok();
            }

            return NotFound($"Not position with name = {Position_name}");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateCaracter(Guid Id, Position position)
        {
            var current_position = _posRep.GetPosition(Id);

            if (current_position != null)
            {
                position.Id = current_position.Id;
                _posRep.UpdatePosition(position);
                return Ok(position);
            }

            return NotFound($"Not position with id = {Id}");
        }
    }
}