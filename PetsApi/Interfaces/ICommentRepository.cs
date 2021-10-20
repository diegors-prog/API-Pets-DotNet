using System.Collections.Generic;
using PetsApi.Models;

namespace PetsApi.Interfaces
{
  public interface ICommentRepository
  {
    Comment GetById(int id);
    List<Comment> GetAll();
    void Save(Comment comment);
    void Delete(Comment comment);
    void Update(Comment comment);
  }
}