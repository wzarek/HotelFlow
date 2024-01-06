using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services
{
    public class UserService
    {
        private readonly HotelFlowContext _context;

        public UserService(HotelFlowContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(r => r.Id == id);
        }

        public List<User> GetUsersByFilter(Expression<Func<User, bool>> filter)
        {
            return _context.Users.Where(filter).ToList();
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(r => r.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
