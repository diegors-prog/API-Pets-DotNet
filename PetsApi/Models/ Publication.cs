using System;
using System.Collections.Generic;

namespace PetsApi.Models
{
  public class Publication
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string TypeAnimal { get; set; }
    public int Views { get; set; }
    public int TotalComments { get; set; }
    public DateTime PublicationDate { get; set; } = DateTime.Now;
    public User User { get; set; }
    public int UserId { get; set; }
  }

}