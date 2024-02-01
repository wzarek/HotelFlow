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

        public enum ReservationStatuses
        {
            [Description("do zatwierdzenia")]
            ToConfirm = 1,

            [Description("zatwierdzona")]
            Confirmed = 2,

            [Description("zameldowano")]
            CheckedIn = 3,

            [Description("wymeldowano")]
            CheckedOut = 4,

            [Description("zamknięta")]
            Closed = 5
        }

        public enum RoomStatuses
        {
            [Description("Clean")]
            Clean = 1,

            [Description("To Clean")]
            ToClean = 2,

            [Description("Taken")]
            Taken = 3
        }

        public enum RoomTypes
        {
            [Description("Family")]
            Family = 1,

            [Description("Family MAX")]
            FamilyMAX = 2,

            [Description("Double")]
            Double = 3,

            [Description("Double PREMIUM")]
            DoublePREMIUM = 4,

            [Description("Single")]
            Single = 5,

            [Description("Triple")]
            Triple = 6
        }

        public enum ObjectTypes
        {
            [Description("Room")]
            Room = 1,

            [Description("Lift")]
            Lift = 2,

            [Description("Corridor")]
            Corridor = 3
        }

        public const string UserNotFoundExceptionMessage = "User not found, more info: {1}";
        public const string OffsetWrongExceptionMessage = "Offset should be higher than 0";
        public const string RoleWrongExceptionMessage = "Role Id should be between 1 and 4";
    }
}
