namespace PetsApi.ViewModels
{
  public class PublicationViewModel
  {
    public PublicationViewModel(int views)
    {
      this.Views = views;
    }
    public int Views { get; set; }
  }
}