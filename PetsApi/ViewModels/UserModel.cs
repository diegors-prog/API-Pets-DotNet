namespace PetsApi.ViewModels
{
  public class UserModel
  {
    public UserModel(int id, string username, string email, string name)
    {
      this.Id = id;
      this.Username = username;
      this.Email = email;
      this.Name = name;
    }
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
  }
}