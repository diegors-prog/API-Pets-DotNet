using System.Collections.Generic;
using PetsApi.Models;

namespace PetsApi.Interfaces
{
  public interface IAuthenticationRepository
  {
    User Authenticate(Authenticate authenticate);
  }
}