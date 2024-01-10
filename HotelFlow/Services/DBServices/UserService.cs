﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Helpers;
using HotelFlow.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services.DBServices
{
    public class UserService
    {
        private readonly HotelFlowContext _context;

        public UserService(HotelFlowContext context)
        {
            _context = context;
        }

        public User GetEmptyUser()
        {
            return new User
            {
                IsActive = true,
                RoleId = (int)Constants.Roles.User,
                DateCreated = DateTime.Now
            };
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers(bool getInactiveUsers = false)
        {
            return _context.Users.Where(u => u.IsActive || getInactiveUsers).ToList();
        }

        public List<User> GetTopNUsersWithOffset(int offset, int n = 50, bool getInactiveUsers = false)
        {
            return _context.Users.Where(u => u.IsActive || getInactiveUsers).Skip(n * offset).Take(n).ToList();
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

        public void UpdateUsers(IEnumerable<User> users)
        {
            _context.Users.UpdateRange(users);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void DeleteUsers(IEnumerable<int> ids)
        {
            var users = _context.Users.Where(u => ids.Contains(u.Id));
            if (users.Any())
            {
                _context.Users.RemoveRange(users);
                _context.SaveChanges();
            }
        }
    }
}
