using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetsApi.Data;
using PetsApi.Interfaces;

namespace PetsApi.Models
{
  public class AuthenticationRepository : IAuthenticationRepository
  {
    private AppDbContext context;

    public AuthenticationRepository(AppDbContext context)
    {
      this.context = context;
    }

    public User Authenticate(Authenticate authenticate)
    {
        return context.Users.SingleOrDefault(x => x.Username == authenticate.Username 
                                            && x.Password == authenticate.Password);
    }

  }
}