namespace PetsApi.ViewModels
{
  public class PublicationTotalCommentsModel
  {
    public PublicationTotalCommentsModel(int totalComments)
    {
      this.TotalComments = totalComments;
    }
    public int TotalComments { get; set; }
  }
}