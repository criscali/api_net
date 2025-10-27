using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using primerApi.Configuration;
using primerApi.DTOs;
using primerApi.Services;

namespace primerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenHandlerService _tokenHandlerService;

        public AuthController(UserManager<IdentityUser> userManager, ITokenHandlerService tokenHandlerService)
        {
            _userManager = userManager;
            _tokenHandlerService = tokenHandlerService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto user)
        {
            if(ModelState.IsValid)
            { 
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if(existingUser != null)
                {
                    return BadRequest("El correo electrónico ya existe.");
                }
                var isCreated = await _userManager.CreateAsync(new IdentityUser
                {
                    UserName = user.Username,
                    Email = user.Email,
                }, user.Password);
                if(isCreated.Succeeded)
                {
                    return Ok("Usuario creado exitosamente.");
                }
                else
                {
                    return BadRequest(isCreated.Errors.Select(x =>x.Description).ToList());
                }
            }
            return BadRequest("Datos inválidos.");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginUser)
        {
            if (ModelState.IsValid)
            {
                var existingEmail = await _userManager.FindByEmailAsync(loginUser.Email);
                if (existingEmail == null)
                {
                    return BadRequest(new LoginResponseDto { 
                        Login = false,
                        Errors = new List<string>() 
                        { 
                            "Correo electrónico o contraseña incorrectos."
                        }
                    });
                }
                var isCorrect = await _userManager.CheckPasswordAsync( existingEmail, loginUser.Password);
                
                if (isCorrect)
                {
                    var pars = new TokeParameters()
                    {
                        Id = existingEmail.Id,
                        PasswordHash = existingEmail.PasswordHash,
                        UserName = existingEmail.UserName,
                    };
                    var jwtToken = _tokenHandlerService.GenerateJwtToken(pars);
                    return Ok( new LoginResponseDto
                    {
                        Login = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new LoginResponseDto
                    {
                        Login = false,
                        Errors = new List<string>()
                        {
                            "Correo electrónico o contraseña incorrectos."
                        }
                    });
                }
            }
            return BadRequest(new LoginResponseDto
            {
                Login = false,
                Errors = new List<string>()
                        {
                            "Correo electrónico o contraseña incorrectos."
                        }
            });
        }

    }
}
