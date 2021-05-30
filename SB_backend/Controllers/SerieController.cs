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
            return Ok(_serRep.GetSeries());
        }
        [HttpGet("{Id}/{initDate}/{endDate}")]
        public IActionResult GetSerie(Guid Id, DateTime initDate, DateTime endDate)
        {
            var serie = _serRep.GetSerie(Id,initDate,endDate);
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
        [HttpPatch("{Id}/{initDate}/{endDate}")]
        public IActionResult UpdateSerie(Guid Id,DateTime initDate,DateTime endDate,Serie serie)
        {
            var current_serie = _serRep.GetSerie(Id,initDate,endDate);

            if (current_serie != null)
            {
                serie.Id = current_serie.Id;
                _serRep.UpdateSerie(serie);
                return Ok(serie);
            }

            return NotFound($"Not Serie with id = {Id}");
        }

        [HttpDelete("{Id}/{initDate}/{endDate}")]
        public IActionResult RemoveSerie(Guid Id, DateTime initDate, DateTime endDate)
        {
            var flag = _serRep.RemoveSerie(Id, initDate, endDate);
            if (flag)
            {
                return Ok();
            }

            return NotFound($"Not Serie with id = {Id}");
        }

    }
}