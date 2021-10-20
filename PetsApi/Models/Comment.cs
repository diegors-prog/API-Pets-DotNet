using System;

namespace PetsApi.Models
{
  public class Comment
  {
    public int Id { get; set; }
    public DateTime CommentDate { get; set; } = DateTime.Now;
    public string CommentContent { get; set; }
    public Publication Publication { get; set; }
    public int PublicationId { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
  }
}