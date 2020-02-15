using System.Threading.Tasks;
using AutoMapper;
using Contract;
using HypertropeCore.DataTransferObjects;
using HypertropeCore.Domain;
using HypertropeCore.Models;
using HypertropeCore.Services;
using Microsoft.AspNetCore.Identity;
 using Microsoft.AspNetCore.Mvc;
 
 namespace HypertropeCore.Controllers
 {
     [ApiController]
     public class AuthenticationController : Controller
     {
         private readonly IMapper _mapper;
         private readonly UserManager<User> _userManager;
         private readonly IAuthenticationManager _authManager;
         private readonly ILoggerManager _loggerManager;

         public AuthenticationController(UserManager<User> userManager, IMapper mapper, 
             IAuthenticationManager authenticationManager, ILoggerManager loggerManager)
         {
             _userManager = userManager;
             _mapper = mapper;
             _authManager = authenticationManager;
             _loggerManager = loggerManager;
         }

         [HttpPost(ApiRoutes.Auth.Ping)]
         public IActionResult Ping()
         {
             _loggerManager.LogInfo("The server was pinged");
             return Ok();
         }

         [HttpPost(ApiRoutes.Auth.Login)]
         public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
         {
             if (!await _authManager.ValidateUser(user))
             {
                 return Unauthorized();
             }

             return Ok(new {Token = await _authManager.CreateToken()});
         }

         [HttpPost(ApiRoutes.Auth.RegisterUser)]
         public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistrationDto)
         {
             var user = _mapper.Map<User>(userRegistrationDto);

             var result = await _userManager.CreateAsync(user, userRegistrationDto.Password);
             if (!result.Succeeded)
             {
                 foreach (var error in result.Errors)
                 {
                     ModelState.TryAddModelError(error.Code, error.Description);
                 }

                 return BadRequest(ModelState);
             }

             await _userManager.AddToRolesAsync(user, userRegistrationDto.Roles);

             return StatusCode(201);
         }
         
     }
 }