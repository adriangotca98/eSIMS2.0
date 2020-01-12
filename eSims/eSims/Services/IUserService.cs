using System.Collections.Generic;
using eSims.Models;

namespace eSims.Services
{
    public interface IUserService
    {
        User Create(User user);
        List<User> Get();
        User Get(string id);
        User GetByUsername(string username);

    }
}
