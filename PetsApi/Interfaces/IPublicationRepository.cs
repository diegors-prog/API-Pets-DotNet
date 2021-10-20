using System.Collections.Generic;
using PetsApi.Models;

namespace PetsApi.Interfaces
{
  public interface IPublicationRepository
  {
    Publication GetById(int id);
    List<Publication> GetAll();
    void Save(Publication publication);
    void Delete(Publication publication);
    void Update(Publication publication);
  }
}