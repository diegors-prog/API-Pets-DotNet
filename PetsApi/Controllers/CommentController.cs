using PetsApi.Interfaces;

namespace PetsApi.Controllers
{
  public class CommentController
  {
    private readonly ICommentRepository comments;

    public CommentController(ICommentRepository commentRepository)
    {
      this.comments = commentRepository;
    }
  }
}