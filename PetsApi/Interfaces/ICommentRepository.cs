using System.Collections.Generic;
using PetsApi.Models;

namespace PetsApi.Interfaces
{
  public interface ICommentRepository
  {
    Comment GetById(int id);
    List<Comment> GetAll();
    void Save(Comment comment);
    void Delete(int id);
    void Update(Comment comment);
  }
}