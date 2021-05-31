using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
            return Ok(_dirRep.GetDirectors());
        }
        [HttpGet("{Id}")]
        public IActionResult GetDirector(Guid Id)
        {
            var director = _dirRep.GetDirector(Id);
            if (director != null)
            {
                return Ok(director);
            }
            return NotFound($"Not Director with Id = {Id}");
        }
        [HttpPost]
        public IActionResult AddDirector([FromForm]Director director)
        {
            this.SaveFile(director);
            director = _dirRep.AddDirector(director);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + director.Id, director);
        }
        [HttpPatch("{Id}")]
        public IActionResult UpdateDirector(Guid Id, [FromForm]Director director)
        {
            var current_director = _dirRep.GetDirector(Id);

            if (current_director != null)
            {
                //System.IO.File.Delete(team.ImgPath);
                this.SaveFile(director);
                director.Id = current_director.Id;
                _dirRep.UpdateDirector(director);
                return Ok(director);
            }

            return NotFound($"Not Director with id = {Id}");
        }

        [HttpDelete("{Id}")]
        public IActionResult RemoveDirector(Guid Id)
        {
            var flag = _dirRep.RemoveDirector(Id);

            if (flag)
            {
                return Ok();
            }

            return NotFound($"Not Serie with id = {Id}");
        }
        void SaveFile(Director director)
        {
            var file = director.Img;
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
                director.ImgPath = dbPath;

            }
        }
    }
}