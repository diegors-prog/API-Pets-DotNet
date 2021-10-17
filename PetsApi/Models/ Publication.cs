using System;

namespace PetsApi.Models
{
  public class Publication
  {
    public int Id { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string TypeAnimal { get; set; }
    public int Views { get; set; }
    public int TotalComments { get; set; }
    public DateTime PublicationDate { get; set; }
  }
}