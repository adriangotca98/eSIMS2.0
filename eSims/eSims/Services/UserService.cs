using eSims.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace eSims.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IeSimsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
            FindUserById(id);

        public User GetByUsername(string username) =>
            FindByUsername(username);

        public User Create(User user)
        {
            if (FindUserById(user.Id) != null)
            {
                return null;
            }
            _users.InsertOne(user);
            return user;
        }
        public User FindUserById(string id) =>
            _users.Find(user => user.Id == id).FirstOrDefault();

        public User FindByUsername(string username) =>
            _users.Find(user => user.Username == username).FirstOrDefault();



    }
}
