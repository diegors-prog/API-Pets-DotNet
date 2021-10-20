namespace PetsApi.ViewModels
{
  public class UserCreateModel
  {
    public UserCreateModel(string username, string email, string password)
    {
      this.Username = username;
      this.Email = email;
      this.Password = password;
    }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  }
}