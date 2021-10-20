using System.Collections.Generic;
using PetsApi.Models;

namespace PetsApi.Interfaces
{
  public interface IPublicationRepository
  {
    Publication GetById(int id);
    List<Publication> GetAll();
    void Save(Publication publication);
    void Delete(int id);
    void Update(Publication publication);
  }
}