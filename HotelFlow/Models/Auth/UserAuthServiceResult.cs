using HotelFlow.Models.DTO;
using HotelFlow.Models.Exceptions;

namespace HotelFlow.Models.Auth
{
    public class UserAuthServiceResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<IValidationException> Errors { get; set; }
        public User User { get; set; }
    }
}
