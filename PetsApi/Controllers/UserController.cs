using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetsApi.Interfaces;
using PetsApi.Models;
using PetsApi.ViewModels;
using System;

namespace PetsApi.Controllers
{
  [ApiController]
  [Route("v1")]
  public class UserController : ControllerBase
  {
    private readonly IUserRepository users;

    public UserController(IUserRepository userRepository)
    {
      this.users = userRepository;
    }

    [HttpGet]
    [Route("user")]

    public IActionResult GetList()
    {
      var listUsers = users.GetAll().Select(x => new
      {
        Id = x.Id,
        Username = x.Username,
        Email = x.Email,
        Image = x.Image,
        Name = x.Name
      })
          .ToList();

      if (listUsers.Count == 0) return NotFound();

      return Ok(listUsers);
    }

    [HttpGet("user/{id}")]
    public IActionResult Get(int id)
    {
      var user = users.GetById(id);

      if (user == null) return NotFound();

      return Ok(new
      {
        Id = user.Id,
        Username = user.Username,
        Email = user.Email,
        Image = user.Image,
        Name = user.Name,
      });
    }

    [HttpPost("userCreate")]
    public IActionResult Post([FromBody] UserCreateModel model)
    {
      if (!ModelState.IsValid) return BadRequest();

      var newUser = new User
      {
        Username = model.Username,
        Email = model.Email,
        Password = model.Password,
        Image = null,
        Name = null
      };

      try
      {
        users.Save(newUser);
        return Ok(model);
      }
      catch (Exception e)
      {
        return BadRequest();
      }
    }

    [HttpPut("userProfile/{id}")]
    public IActionResult Put([FromBody] UserProfileModel model, [FromRoute] int id)
    {

      if (!ModelState.IsValid) return BadRequest();

      var user = users.GetById(id);

      if (user == null) return NotFound();

      try
      {
        user.Image = model.Image;
        user.Name = model.Name;

        users.Update(user);
        return Ok(model);
      }
      catch (Exception e)
      {
        return BadRequest();
      }
    }

    [HttpDelete("user/{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
      var user = users.GetAll().Find(x => x.Id == id);

      if (user == null)
      {
        return NotFound();
      }

      try
      {
        users.Delete(user);
        return Ok(new
        {
          message = "Usuário deletado com sucesso!",
          id = id
        });
      }
      catch (Exception e)
      {
        return BadRequest();
      }

    }
  }
}