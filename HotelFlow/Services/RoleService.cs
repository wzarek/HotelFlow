using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HotelFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Services
{
    public class RoleService
    {
        private readonly HotelFlowContext _context;

        public RoleService(HotelFlowContext context)
        {
            _context = context;
        }

        public Role CreateRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.Id == id);
        }

        public List<Role> GetRolesByFilter(Expression<Func<Role, bool>> filter)
        {
            return _context.Roles.Where(filter).ToList();
        }

        public Role UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role;
        }

        public void DeleteRole(int id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }
    }
}
