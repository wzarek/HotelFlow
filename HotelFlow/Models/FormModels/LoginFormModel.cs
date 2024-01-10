using System.ComponentModel.DataAnnotations;

namespace HotelFlow.Models.FormModels
{
    public class LoginFormModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
