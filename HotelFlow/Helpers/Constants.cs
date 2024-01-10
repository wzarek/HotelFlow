using System.ComponentModel;

namespace HotelFlow.Helpers
{
    public static class Constants
    {
        public enum Roles
        {
            [Description("Admin")]
            Admin = 1,

            [Description("Employee")]
            Employee = 2,

            [Description("User")]
            User = 3,

            [Description("Guest")]
            Guest = 4
        }

        public const string UserNotFoundExceptionMessage = "User not found, more info: {1}";
        public const string OffsetWrongExceptionMessage = "Offset should be higher than 0";
        public const string RoleWrongExceptionMessage = "Role Id should be between 1 and 4";
    }
}
