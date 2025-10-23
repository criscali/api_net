using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using primerApi.Application;
using primerApi.DataAccess;
using primerApi.Entities;

namespace primerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutbolTeamController : ControllerBase
    {
        IApplication<FutbolTeam> _futbolTeamApplication;
        
        public FutbolTeamController(IApplication<FutbolTeam> futbolTeam)
        { 
            _futbolTeamApplication = futbolTeam;
            
        }



        [HttpGet]
        public IActionResult Get()
        {
            //var result = _futbolTeamApplication.GetAll();
            return Ok(_futbolTeamApplication.GetAll());
        }
        [HttpPost]
        public IActionResult Post([FromBody] FutbolTeam futbolTeam)
        {
            var result = _futbolTeamApplication.Save(futbolTeam);
            return Ok(result);
        }

    }
}
