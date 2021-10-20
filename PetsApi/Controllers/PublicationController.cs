using System;
using Microsoft.AspNetCore.Mvc;
using PetsApi.Interfaces;
using PetsApi.Models;
using PetsApi.ViewModels;

namespace PetsApi.Controllers
{
  [ApiController]
  [Route("v1")]
  public class PublicationController : ControllerBase
  {
    private readonly IPublicationRepository publications;

    public PublicationController(IPublicationRepository publicationRepository)
    {
      this.publications = publicationRepository;
    }

    [HttpGet]
    [Route("publication")]
    public IActionResult GetList()
    {
      var listPublications = publications.GetAll();

      if (listPublications.Count == 0) return NotFound();

      return Ok(listPublications);
    }

    [HttpGet("publication/{id}")]
    public IActionResult Get(int id)
    {
      var publication = publications.GetById(id);

      if (publication == null) return NotFound();

      return Ok(publication);
    }

    [HttpPost("publicationCreate")]
    public IActionResult Post([FromBody] PublicationCreateModel model)
    {
      if (!ModelState.IsValid) return BadRequest();

      var newPublication = new Publication
      {
        Title = model.Title,
        Description = model.Description,
        TypeAnimal = model.TypeAnimal,
        Image = model.Image,
        Views = 0,
        TotalComments = 0,
        PublicationDate = DateTime.Now,
        UserId = model.UserId,
      };

      try
      {
        publications.Save(newPublication);
        return Ok(newPublication);
      }
      catch (Exception e)
      {
        return BadRequest();
      }
    }

    [HttpPut("publicationViews/{id}")]
    public IActionResult Put([FromBody] PublicationViewModel model,
                        [FromRoute] int id)
    {
      if (!ModelState.IsValid) return BadRequest();

      var publication = publications.GetById(id);

      if (publication == null) return NotFound();

      try
      {
        publication.Views = publication.Views + model.Views;
        publications.Update(publication);
        return Ok(new
        {
          message = "Número de visualizações atualizada",
          views = publication.Views,
          id = id,

        });
      }
      catch (Exception e)
      {
        return BadRequest();
      }
    }

    [HttpDelete("publication/{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
      var publication = publications.GetById(id);

      if (publication == null) return NotFound();

      try
      {
        publications.Delete(publication);
        return Ok(new
        {
          message = "Publicação deletada com sucesso!",
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