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
    public class DirectorController : ControllerBase
    {
        private IDirectorRepository _dirRep;
        public DirectorController(IDirectorRepository repo)
        {
            _dirRep = repo;
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            return Ok(_dirRep.getDirectors());
        }
        [HttpGet("{Id}")]
        public IActionResult GetDirector(Guid Id)
        {
            var director = _dirRep.getDirector(Id);
            if (director != null)
            {
                return Ok(director);
            }
            return NotFound($"Not Director with Id = {Id}");
        }
        [HttpPost]
        public IActionResult AddDirector(Director director)
        {
            director = _dirRep.AddDirector(director);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + director.Id, director);
        }
        [HttpPatch("{Id}")]
        public IActionResult UpdateDirector(Guid Id, Director director)
        {
            var current_director = _dirRep.getDirector(Id);

            if (current_director != null)
            {
                director.Id = current_director.Id;
                _dirRep.UpdateDirector(director);
                return Ok(director);
            }

            return NotFound($"Not Director with id = {Id}");
        }

        [HttpDelete("{Id}")]
        public IActionResult RemoveDirector(Guid Id)
        {
            var director = _dirRep.getDirector(Id);

            if (director != null)
            {
                _dirRep.RemoveDirector(director);
                return Ok();
            }

            return NotFound($"Not Serie with id = {Id}");
        }
    }
}