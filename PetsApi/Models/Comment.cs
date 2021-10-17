using System;

namespace PetsApi.Models
{
  public class Comment
  {
    public int Id { get; set; }
    public int PublicationId { get; set; }
    public int UserId { get; set; }
    public string Author { get; set; }
    public DateTime CommentDate { get; set; }
    public string CommentContent { get; set; }
  }
}