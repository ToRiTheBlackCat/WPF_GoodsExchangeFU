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
        private ExchangeRepository _ex_repo = new();
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
        public User GetUserById(int id)
        {
            return _repo.GetAllUsers().FirstOrDefault(u => u.UserId == id);
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


        public void RegisterUser(User user)
        {
            _repo.CreateUser(user);
        }
        public User? GetUserByName(string userName)
        {
            return _repo.GetUsersByName(userName);
        }

        public bool UpdateUser(User user)
        {
            return _repo.UpdateUser(user);
        }
        public double GetAveScore(User user)
        {
            var listScore = _repo.GetAllScoresOfUser(user);
            return  (listScore != null && listScore.Any()) ?(double)listScore.Average() : 0;
        }
        public List<Rating> GetRatingsOfUser(User user)
        {
            return _repo.GetAllRating(user);
        }

        public bool FindRatingByExId(int exId)
        {
            var ex = _ex_repo.GetExchanges(exId);
            if (ex != null)
                return true;

            return false;
        }
        public void AddRatingAndComment(Rating rating)
        {
             _repo.AddRating(rating);
        }
    }
}
