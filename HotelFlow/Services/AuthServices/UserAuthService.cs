using HotelFlow.Helpers;
using HotelFlow.Models.Auth;
using HotelFlow.Models.DTO;
using HotelFlow.Models.Exceptions;
using HotelFlow.Validators;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HotelFlow.Services.AuthServices
{
    public class UserAuthService
    {
        private readonly HotelFlowContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserAuthService(HotelFlowContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<UserAuthServiceResult> CreateUserAsync(User user, string password)
        {
            try
            {
                var validationErrors = UserValidator.ValidateUser(user);
                if (validationErrors.Any())
                {
                    return new UserAuthServiceResult { Succeeded = false, Errors = validationErrors };
                }

                user.Password = _passwordHasher.HashPassword(null, password);
                var added = _context.Users.AddIfNotExists(user, u => u.UserName == user.UserName || u.EmailAddress == user.EmailAddress);

                if (added == null)
                {
                    var exception = new UserValidationException("User already exists");
                    return new UserAuthServiceResult { Succeeded = false, Errors = new List<IValidationException> { exception } };
                }

                await _context.SaveChangesAsync();

                return new UserAuthServiceResult { Succeeded = true, User = user };
            }
            catch (Exception ex)
            {
                return new UserAuthServiceResult
                {
                    Succeeded = false,
                    Errors = new List<IValidationException> { new UserValidationException("An error occurred while creating the user.", ex) }
                };
            }
        }

        public User ValidateCredentials(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.EmailAddress == email);
            if (user != null)
            {
                var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
                if (result == PasswordVerificationResult.Success)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<User> GetUserAsync(ClaimsPrincipal principal)
        {
            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return null;
            }

            int userId = int.Parse(userIdClaim);
            return await _context.Users.FindAsync(userId);
        }
    }
}
