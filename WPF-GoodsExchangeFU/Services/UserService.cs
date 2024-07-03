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
    }
}
