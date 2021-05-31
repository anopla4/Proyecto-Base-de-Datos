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
    public class TeamController : ControllerBase
    {
        private ITeamRepository _teamRep;
        public TeamController(ITeamRepository repo)
        {
            _teamRep = repo;
        }

        [HttpGet]
        public IActionResult getTeams()
        {
            return Ok(_teamRep.getTeams());
        }


        [HttpPost]
        public IActionResult AddTeam([FromForm]Team team)
        {
            this.SaveFile(team);

            _teamRep.AddTeam(team);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + team.Id, team);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTeam(Guid Id)
        {
            var team = _teamRep.getTeam(Id);

            if (team != null)
            {
                _teamRep.RemoveTeam(team);
                return Ok();
            }

            return NotFound($"Not Team with id = {Id}");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateTeam(Guid Id, [FromForm]Team team)
        {
            var current_team = _teamRep.getTeam(Id);

            if (current_team != null)
            {
                //System.IO.File.Delete(team.ImgPath);
                this.SaveFile(team);
                team.Id = current_team.Id;
                _teamRep.UpdateTeam(team);
                return Ok(team);
            }

            return NotFound($"Not team with id = {Id}");
        }

        void SaveFile(Team team)
        {
            var file = team.Img;
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
                team.ImgPath = dbPath;

            }
        }

    }
}