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
            try 
            {
                var serie = _serRep.GetSerie(Id,initDate,endDate);
                return Ok(serie);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddSerie(Serie serie)
        {
            try
            {
                serie = _serRep.AddSerie(serie);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + serie.Id, serie);
            }
            catch (Exception e) { return BadRequest(e.Message); }
            
        }
        [HttpPatch("{Id}/{initDate}/{endDate}")]
        [Authorize]
        public IActionResult UpdateSerie(Guid Id,DateTime initDate,DateTime endDate,Serie serie)
        {
            try
            {
                var current_serie = _serRep.GetSerie(Id, initDate, endDate);

                serie.Id = current_serie.Id;
                _serRep.UpdateSerie(serie);
                return Ok(serie);
            }

            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{Id}/{initDate}/{endDate}")]
        [Authorize]
        public IActionResult RemoveSerie(Guid Id, DateTime initDate, DateTime endDate)
        {
            try
            {
                var flag = _serRep.RemoveSerie(Id, initDate, endDate);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}