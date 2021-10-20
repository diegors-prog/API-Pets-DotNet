using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetsApi.Data;
using PetsApi.Interfaces;

namespace PetsApi.Models
{
  public class PublicationRepository : IPublicationRepository
  {
    private AppDbContext context;

    public PublicationRepository(AppDbContext context)
    {
      this.context = context;
    }

    public Publication GetById(int id)
    {
      return context.Publications.SingleOrDefault(x => x.Id == id);
    }

    public List<Publication> GetAll()
    {
      return context.Publications.ToList();
    }

    public void Save(Publication publication)
    {
      context.Publications.Add(publication);
      context.SaveChanges();
    }

    public void Delete(int id)
    {
      context.Publications.Remove(GetById(id));
      context.SaveChanges();
    }

    public void Update(Publication publication)
    {
      context.Entry(publication).State = EntityState.Modified;
      context.SaveChanges();
    }
  }
}