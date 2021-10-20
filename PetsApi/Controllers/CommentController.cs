using System;
using Microsoft.AspNetCore.Mvc;
using PetsApi.Interfaces;
using PetsApi.Models;
using PetsApi.ViewModels;

namespace PetsApi.Controllers
{
  [ApiController]
  [Route("v1")]
  public class CommentController : ControllerBase
  {
    private readonly ICommentRepository comments;

    public CommentController(ICommentRepository commentRepository)
    {
      this.comments = commentRepository;
    }

    [HttpGet]
    [Route("comment")]
    public IActionResult GetList()
    {
      var listComments = comments.GetAll();

      if (listComments.Count == 0) return NotFound();

      return Ok(listComments);
    }

    [HttpGet("comment/{id}")]
    public IActionResult Get(int id)
    {
      var comment = comments.GetById(id);

      if (comment == null) return NotFound();

      return Ok(comment);
    }

    [HttpPost("commentCreate")]
    public IActionResult Post([FromBody] CommentCreateModel model)
    {
      if (!ModelState.IsValid) return BadRequest();

      var newComment = new Comment
      {
        CommentDate = DateTime.Now,
        CommentContent = model.CommentContent,
        PublicationId = model.PublicationId,
        UserId = model.UserId,
      };

      try
      {
        comments.Save(newComment);
        return Ok(newComment);
      }
      catch (Exception e)
      {
        return BadRequest();
      }
    }

    [HttpPut("commentContent/{id}")]
    public IActionResult Put([FromBody] CommentContentModel model,
                        [FromRoute] int id)
    {
      if (!ModelState.IsValid) return BadRequest();

      var comment = comments.GetById(id);

      if (comment == null) return NotFound();

      try
      {
        comment.CommentContent = model.CommentContent;
        comments.Update(comment);
        return Ok(new
        {
          message = "Comentário atualizado com sucesso!",
          commentContent = comment.CommentContent,
          id = id,
        });
      }
      catch (Exception e)
      {
        return BadRequest();
      }
    }

    [HttpDelete("comment/{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
      var comment = comments.GetById(id);

      if (comment == null) return NotFound();

      try
      {
        comments.Delete(comment);
        return Ok(new
        {
          message = "Comentário deletado com sucesso!",
          id = id,
        });
      }
      catch (Exception e)
      {
        return BadRequest();
      }
    }
  }
}