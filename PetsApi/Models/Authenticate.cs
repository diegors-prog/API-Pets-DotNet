namespace PetsApi.Models
{
  public class Authenticate
  {
      public Authenticate(string username, string password)
      {
          this.Username = username;
          this.Password = password;
      }
    public string Username { get; set; }
    public string Password { get; set; }
  }
}