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
    public class SerieController : ControllerBase
    {
        private ISerieRepository _serRep;
        public SerieController(ISerieRepository repo)
        {
            _serRep = repo;
        }

        [HttpGet]
        public IActionResult GetSeries()
        {
            return Ok(_serRep.getSeries());
        }
        [HttpGet("{Id}")]
        public IActionResult GetSerie(Guid Id)
        {
            var serie = _serRep.getSerie(Id);
            if(serie != null)
            {
                return Ok(serie);
            }
            return NotFound($"Not serie with Id = {Id}");
        }
        [HttpPost]
        public IActionResult AddSerie(Serie serie)
        {
            serie = _serRep.AddSerie(serie);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + serie.Id, serie);
        }
        [HttpPatch("{Id}")]
        public IActionResult UpdateSerie(Guid Id,Serie serie)
        {
            var current_serie = _serRep.getSerie(Id);

            if (current_serie != null)
            {
                serie.Id = current_serie.Id;
                _serRep.UpdateSerie(serie);
                return Ok(serie);
            }

            return NotFound($"Not Serie with id = {Id}");
        }

        [HttpDelete("{Id}")]
        public IActionResult RemoveSerie(Guid Id,Serie serie)
        {
            var flag = _serRep.RemoveSerie(serie);
            if (flag)
            {
               return Ok();
            }

            return NotFound($"Not Serie with id = {Id}");
        }

    }
}