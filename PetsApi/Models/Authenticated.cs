namespace PetsApi.Models
{
  public class Authenticated
  {
    public string Token { get; set; }
    public User User { get; set; }
  }
}