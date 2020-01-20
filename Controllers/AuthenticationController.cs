using System.Threading.Tasks;
using AutoMapper;
using HypertropeCore.DataTransferObjects;
using HypertropeCore.Models;
 using Microsoft.AspNetCore.Identity;
 using Microsoft.AspNetCore.Mvc;
 
 namespace HypertropeCore.Controllers
 {
     [ApiController]
     public class AuthenticationController : Controller
     {
         private readonly IMapper _mapper;
         private readonly UserManager<User> _userManager;

         public AuthenticationController(UserManager<User> userManager, IMapper mapper)
         {
             _userManager = userManager;
             _mapper = mapper;
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