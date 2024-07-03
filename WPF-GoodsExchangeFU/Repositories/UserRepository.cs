using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository
    {
        GoodsExchangeFudbContext _context;
        public void UpdateUser(User user)
        {
            _context = new();
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public User GetUser(int userId)
        {
            _context = new();
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }
    }
}
