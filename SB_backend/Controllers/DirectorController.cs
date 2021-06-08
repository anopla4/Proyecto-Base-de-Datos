using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
            try
            {
                var director = _dirRep.GetDirector(Id);
                return Ok(director);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }    
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddDirector([FromForm] Director director)
        {
            try 
            {
                this.SaveFile(director);
                director = _dirRep.AddDirector(director);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + director.Id, director);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPatch("{Id}")]
        [Authorize]
        public IActionResult UpdateDirector(Guid Id, [FromForm]Director director)
        {
            try
            {
                var current_director = _dirRep.GetDirector(Id);

                if(director.Img != null)
                {
                    if (current_director.ImgPath != null)
                        System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), current_director.ImgPath));
                    this.SaveFile(director);
                }
                
                director.Id = current_director.Id;
                _dirRep.UpdateDirector(director);
                return Ok(director);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpDelete("{Id}")]
        [Authorize]
        public IActionResult RemoveDirector(Guid Id)
        {
            try
            {
                var flag = _dirRep.RemoveDirector(Id);
                return Ok();
            }
            catch (Exception e)

            {
                return NotFound(e.Message);
            }
        }
        void SaveFile(Director director)
        {
            var file = director.Img;
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file != null && file.Length > 0)
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