using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetsApi.Data;
using PetsApi.Interfaces;

namespace PetsApi.Models
{
  public class CommentRepository : ICommentRepository
  {
    private AppDbContext context;

    public CommentRepository(AppDbContext context)
    {
      this.context = context;
    }

    public Comment GetById(int id)
    {
      return context.Comments.SingleOrDefault(x => x.Id == id);
    }

    public List<Comment> GetAll()
    {
      return context.Comments.ToList();
    }

    public void Save(Comment comment)
    {
      context.Comments.Add(comment);
      context.SaveChanges();
    }

    public void Delete(int id)
    {
      context.Comments.Remove(GetById(id));
      context.SaveChanges();
    }

    public void Update(Comment comment)
    {
      context.Entry(comment).State = EntityState.Modified;
      context.SaveChanges();
    }
  }
}