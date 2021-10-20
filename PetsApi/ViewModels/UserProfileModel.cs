namespace PetsApi.ViewModels
{
  public class UserProfileModel
  {

    public UserProfileModel(string image, string name)
    {
      this.Image = image;
      this.Name = name;
    }
    public string Image { get; set; }
    public string Name { get; set; }

  }
}