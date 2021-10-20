namespace PetsApi.ViewModels
{
  public class PublicationCreateModel
  {
    public PublicationCreateModel(int userId, string title, string description, string typeAnimal, string image)
    {
      this.UserId = userId;
      this.Title = title;
      this.Description = description;
      this.TypeAnimal = typeAnimal;
      this.Image = image;
    }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string TypeAnimal { get; set; }
    public string Image { get; set; }

  }
}