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
      var listUsers = users.GetAll().Select(x => new { Id = x.Id, Username = x.Username, Email = x.Email, Name = x.Name }).ToList();

      if (listUsers.Count == 0)
      {
        return NotFound();
      }

      return Ok(listUsers);
    }

    [HttpGet("user/{id}")]
    public IActionResult Get(int id)
    {
      var user = users.GetById(id);

      if (user == null)
      {
        return NotFound();
      }

      return Ok(new
      {
        Id = user.Id,
        Username = user.Username,
        Email = user.Email,
        Name = user.Name,
      });
    }

    [HttpPost("userCreate")]
    public IActionResult Post([FromBody] UserCreateModel user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      var userNew = new User
      {
        Username = user.Username,
        Email = user.Email,
        Password = user.Password,
        Image = null,
        Name = null
      };

      try
      {
        users.Save(userNew);
        return Ok(user);
      }
      catch (Exception e)
      {
        return BadRequest();
      }
    }

    [HttpPut("userProfile/{id}")]
    public IActionResult Put([FromBody] UserProfileModel model, [FromRoute] int id)
    {

      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      var user = users.GetById(id);

      if (user == null)
      {
        return NotFound();
      }

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

    [HttpDelete("user/{Id}")]
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
        });
      }
      catch (Exception)
      {
        return BadRequest();
      }

    }
  }
}