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
    public class CaracterController : ControllerBase
    {
        private ICaracterRepository _caractRep;
        public CaracterController(ICaracterRepository repo)
        {
            _caractRep = repo;
        }

        [HttpGet]
        public IActionResult GetCaracters()
        {
            return Ok(_caractRep.getCaracters());
        }
        [HttpGet("{Id}")]
        public IActionResult GetCaracter(Guid Id)
        {
            var caracter = _caractRep.getCaracter(Id);

            if (caracter != null)
            {
                return Ok(caracter);
            }

            return NotFound($"Not caracter with id = {Id}");
        }

        [HttpPost]
        public IActionResult AddCaracter(Caracter caracter)
        {
            _caractRep.AddCaracter(caracter);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + caracter.Id, caracter);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCaracter(Guid Id)
        {
            var caracter = _caractRep.getCaracter(Id);

            if (caracter != null)
            {
                _caractRep.RemoveCaracter(caracter);
                return Ok();
            }

            return NotFound($"Not caracter with id = {Id}");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateCaracter(Guid Id, Caracter caracter)
        {
            var current_caracter = _caractRep.getCaracter(Id);

            if (current_caracter != null)
            {
                caracter.Id = current_caracter.Id;
                _caractRep.UpdateCaracter(caracter);
                return Ok(caracter);
            }

            return NotFound($"Not caracter with id = {Id}");
        }
    }
}