using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using primerApi.Application;
using primerApi.DataAccess;
using primerApi.DTOs;
using primerApi.Entities;

namespace primerApi.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class FutbolTeamController : ControllerBase
    {
        IApplication<FutbolTeam> _futbolTeamApplication;

        public FutbolTeamController(IApplication<FutbolTeam> futbolTeamApplication)
        {
            _futbolTeamApplication = futbolTeamApplication;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //var result = _futbolTeamApplication.GetAll();
            return Ok(_futbolTeamApplication.GetAll());
        }

        [HttpPost]
        public IActionResult Save([FromBody] FutbolTeamDto dto)
        {
            //var result = _futbolTeamApplication.Save(dto);
            //return Ok(result);
            var f = new FutbolTeam()
            {
                Nombre = dto.Nombre,
                puntaje = dto.puntaje,
                Manager = dto.Manager

            };
            return Ok(_futbolTeamApplication.Save(f));
        }
        [HttpPost("CargarExcel")]
        public IActionResult CargarExcel(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return BadRequest("Por favor selecciona un archivo válido.");
                
            }
            _futbolTeamApplication.CrearExcel(archivo);
            return Ok();


        }

    }
}
