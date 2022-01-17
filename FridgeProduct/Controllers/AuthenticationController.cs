using AutoMapper;
using FridgeProduct.Contracts;
using FridgeProduct.Entities.DataTransferObjects;
using FridgeProduct.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FridgeProduct.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
        public AuthenticationController(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IAuthenticationManager authManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto
            userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                return Unauthorized();
            }
            try
            {
                return Ok(new { Token = await _authManager.CreateToken() });
            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}
