using HotelFlow.Helpers;
using HotelFlow.Models.DTO;

namespace HotelFlow.Services.AuthServices
{
    public class RoleAuthService
    {
        private readonly HotelFlowContext _context;

        public RoleAuthService(HotelFlowContext context)
        {
            _context = context;
        }

        public async Task<Constants.Roles> GetUserRoleAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user != null ? (Constants.Roles)user.RoleId : Constants.Roles.Guest;
        }
    }
}
