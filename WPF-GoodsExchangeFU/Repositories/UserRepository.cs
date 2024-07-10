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
        public bool UpdateUser(User user)
        {
            try
            {
                _context = new();
                _context.Users.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
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
            _context = new();
            return _context.Users.FirstOrDefault(u => u.UserName.Equals(text));
        }
        public List<User> GetUsers()
        {
            _context = new ();
            return _context.Users.ToList();
        }
        public List<decimal>? GetAllScoresOfUser(User user)
        {
            _context = new();
            return _context.Ratings.Where(r => r.UserId == user.UserId).Select(r => r.Score).ToList();
        }
        public List<Rating>? GetAllRating(User user)
        {
            _context = new();
            return _context.Ratings.Include(r => r.Exchange)
                                        .ThenInclude(e => e.User)
                                    .Where(r => r.UserId == user.UserId).ToList();
        }
    }
}
