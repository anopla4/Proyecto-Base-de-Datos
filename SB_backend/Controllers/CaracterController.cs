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
            return Ok(_caractRep.GetCaracters());
        }
        [HttpGet("{Id}")]
        public IActionResult GetCaracter(Guid Id)
        {
            try 
            { 
                var caracter = _caractRep.GetCaracter(Id);
                return Ok(caracter);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
                
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddCaracter(Caracter caracter)
        {
            try
            {
                _caractRep.AddCaracter(caracter);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + caracter.Id, caracter);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult RemoveCaracter(Guid Id, Caracter caracter)
        {
            try
            {
                var flag = _caractRep.RemoveCaracter(caracter);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPatch("{id}")]
        [Authorize]
        public IActionResult UpdateCaracter(Guid Id, Caracter caracter)
        {
            try
            {
                var current_caracter_Upd = _caractRep.UpdateCaracter(caracter);
                return Ok(caracter);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}