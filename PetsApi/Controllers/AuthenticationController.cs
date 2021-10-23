using System;
using Microsoft.AspNetCore.Mvc;
using PetsApi.Interfaces;
using PetsApi.Services;
using PetsApi.Models;
using Microsoft.AspNetCore.Authorization;
using PetsApi.ViewModels;

namespace PetsApi.Controllers
{
  [ApiController]
  [Route("v1")]
  public class AuthenticationController : ControllerBase
  {
      private readonly IAuthenticationRepository authentication;

      public AuthenticationController(IAuthenticationRepository authentication)
    {
        this.authentication = authentication;
    }

    [HttpPost("authenticate")]
    public IActionResult Post([FromBody] AuthenticationViewModel model)
    {
        var authenticate = new Authenticate(model.Username, model.Password);
        var user = authentication.Authenticate(authenticate);

        if (user == null) 
        {
            return Unauthorized();
        }

        var token = TokenService.GenerateToken(user);
        user.Password = "";

        var authenticated = new Authenticated();
        authenticated.Token = token;
        authenticated.User = user;

        return Ok(authenticated);
    }
  }
}