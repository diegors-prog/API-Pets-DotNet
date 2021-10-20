namespace PetsApi.ViewModels
{
  public class CommentCreateModel
  {
    public CommentCreateModel(int publicationId, int userId, string commentContent)
    {
      this.PublicationId = publicationId;
      this.UserId = userId;
      this.CommentContent = commentContent;
    }
    public int PublicationId { get; set; }
    public int UserId { get; set; }
    public string CommentContent { get; set; }
  }
}