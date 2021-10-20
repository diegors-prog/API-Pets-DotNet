namespace PetsApi.ViewModels
{
  public class CommentContentModel
  {
    public CommentContentModel(string commentContent)
    {
      this.CommentContent = commentContent;
    }
    public string CommentContent { get; set; }
  }
}