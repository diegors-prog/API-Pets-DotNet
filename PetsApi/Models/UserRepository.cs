using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetsApi.Data;
using PetsApi.Interfaces;

namespace PetsApi.Models
{
  public class UserRepository : IUserRepository
  {
    private AppDbContext context;

    public UserRepository(AppDbContext context)
    {
      this.context = context;
    }

    public User GetById(int id)
    {
      return context.Users.SingleOrDefault(x => x.Id == id);
    }

    public List<User> GetAll()
    {
      return context.Users.ToList();
    }

    public void Save(User user)
    {
      context.Users.Add(user);
      context.SaveChanges();
    }

    public void Delete(User user)
    {
      context.Users.Remove(user);
      context.SaveChanges();
    }

    public void Update(User user)
    {
      context.Entry(user).State = EntityState.Modified;
      context.SaveChanges();
    }
  }
}