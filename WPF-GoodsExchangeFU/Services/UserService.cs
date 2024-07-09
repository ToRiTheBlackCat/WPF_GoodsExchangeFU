using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {
        private UserRepository _repo = new();

        public void BanUser(int userId)
        {
            var user = _repo.GetUser(userId);
            if (user != null)
            {
                user.IsBanned = true;
                _repo.UpdateUser(user);
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public User? AuthenticateUser(string email, string password)
        {
            return _repo.GetUserByEmailandPassword(email, password);
        }

        public List<User> GetAllUSer()
        {
            return _repo.GetAllUsers();
        }
        public void CreateUser(User user)
        {
            _repo.CreateUser(user);
        }

        public void DeleteUser(int userId)
        {
            _repo.DeleteUser(userId);
        }

        public List<Exchange> GetAllExchange()
        {
            return _repo.GetAllExchange();
        }
        public User? GetUserByName(string userName)
        {
            return _repo.GetUsersByName(userName);
        }

        public bool UpdateUser(User user)
        {
            return _repo.UpdateUser(user);
        }
    }
}
