using HotelFlow.Models.DTO;
using HotelFlow.Models.Exceptions;

namespace HotelFlow.Validators
{
    public static class UserValidator
    {
        public static IEnumerable<IValidationException> ValidateUser(User user)
        {
            var errors = new List<IValidationException>();

            if (string.IsNullOrWhiteSpace(user.EmailAddress))
            {
                errors.Add(new UserValidationException("Email is required."));
            }

            // to add more...

            return errors;
        }
    }
}
