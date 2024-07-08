using Microsoft.EntityFrameworkCore;
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

        public User GetUserByEmailandPassword(string email, string password)
        {
            _context = new();
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        public List<User> GetAllUsers()
        {
            _context = new();
            return _context.Users.ToList();
        }

        public void CreateUser(User user)
        {
            _context = new();
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void DeleteUser(int userId)
        {
            _context = new();
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }


        public List<Exchange> GetAllExchange() { 
            _context= new();
            return _context.Exchanges.ToList();
        }

        public User? GetUsersByName(string text)
        {
            return _context.Users.FirstOrDefault(u => u.UserName.Equals(text));
        }
        public List<User> GetUsers()
        {
            _context = new GoodsExchangeFudbContext();
            return _context.Users.ToList();
        }
    }
}
