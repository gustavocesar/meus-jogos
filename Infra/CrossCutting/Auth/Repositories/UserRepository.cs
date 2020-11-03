using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MeusJogos.Infra.CrossCutting.Auth.Models;

namespace MeusJogos.Infra.CrossCutting.Auth.Repositories
{
  public static class UserRepository
  {
    //TODO: remover o Mock de usuários
    private static List<User> UsersMock()
    {
      return new List<User>
      {
        new User { Id = 1, Username = "admin", Password = "123456", Role = "Administrador" },
        new User { Id = 1, Username = "user", Password = "123456", Role = "Usuario" },
      };
    }

    public static User Get(string username, string password)
    {
      var users = UserRepository.UsersMock();

      return users.Where(x => x.Username.ToLower() == username && x.Password == password).FirstOrDefault();
    }
  }
}
