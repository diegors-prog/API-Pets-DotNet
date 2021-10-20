using System.Collections.Generic;
using PetsApi.Models;

namespace PetsApi.Interfaces
{
  public interface IUserRepository
  {
    User GetById(int id);
    List<User> GetAll();
    void Save(User user);
    void Delete(User user);
    void Update(User user);
  }
}