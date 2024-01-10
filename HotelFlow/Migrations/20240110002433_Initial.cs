using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelFlow.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Rooms");

            migrationBuilder.EnsureSchema(
                name: "Visuals");

            migrationBuilder.EnsureSchema(
                name: "Base");

            migrationBuilder.EnsureSchema(
                name: "Business");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "FloorSchema",
                schema: "Visuals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorSchema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CheckInTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CheckOutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectType",
                schema: "Visuals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationStatus",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomStatus",
                schema: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                schema: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK__User__RoleId__5165187F",
                        column: x => x.RoleId,
                        principalSchema: "Users",
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                schema: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Room__StatusId__534D60F1",
                        column: x => x.StatusId,
                        principalSchema: "Rooms",
                        principalTable: "RoomStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Room__TypeId__52593CB8",
                        column: x => x.TypeId,
                        principalSchema: "Rooms",
                        principalTable: "RoomType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CleaningHistory",
                schema: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DateCleaned = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK__CleaningH__Emplo__571DF1D5",
                        column: x => x.EmployeeId,
                        principalSchema: "Users",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__CleaningH__RoomI__5629CD9C",
                        column: x => x.RoomId,
                        principalSchema: "Rooms",
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CleaningSchedule",
                schema: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DateToBeCleaned = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK__CleaningS__Emplo__5535A963",
                        column: x => x.EmployeeId,
                        principalSchema: "Users",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__CleaningS__RoomI__5441852A",
                        column: x => x.RoomId,
                        principalSchema: "Rooms",
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ObjectPlacement",
                schema: "Visuals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectTypeId = table.Column<int>(type: "int", nullable: false),
                    FloorNumberId = table.Column<int>(type: "int", nullable: false),
                    PositionFrom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PositionTo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectPlacement", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ObjectPla__Floor__5DCAEF64",
                        column: x => x.FloorNumberId,
                        principalSchema: "Visuals",
                        principalTable: "FloorSchema",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ObjectPla__Objec__5CD6CB2B",
                        column: x => x.ObjectTypeId,
                        principalSchema: "Visuals",
                        principalTable: "ObjectType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ObjectPla__RoomI__5EBF139D",
                        column: x => x.RoomId,
                        principalSchema: "Rooms",
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DateTo = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Reservati__Custo__5812160E",
                        column: x => x.CustomerId,
                        principalSchema: "Users",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Reservati__Emplo__59063A47",
                        column: x => x.EmployeeId,
                        principalSchema: "Users",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Reservati__RoomI__59FA5E80",
                        column: x => x.RoomId,
                        principalSchema: "Rooms",
                        principalTable: "Room",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Reservati__Statu__5AEE82B9",
                        column: x => x.StatusId,
                        principalSchema: "Business",
                        principalTable: "ReservationStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Review__Reservat__5BE2A6F2",
                        column: x => x.ReservationId,
                        principalSchema: "Business",
                        principalTable: "Reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleaningHistory_EmployeeId",
                schema: "Rooms",
                table: "CleaningHistory",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningHistory_RoomId",
                schema: "Rooms",
                table: "CleaningHistory",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningSchedule_EmployeeId",
                schema: "Rooms",
                table: "CleaningSchedule",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningSchedule_RoomId",
                schema: "Rooms",
                table: "CleaningSchedule",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "UQ__FloorSch__632D9B2BEB59EC8A",
                schema: "Visuals",
                table: "FloorSchema",
                column: "FloorNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ObjectPlacement_FloorNumberId",
                schema: "Visuals",
                table: "ObjectPlacement",
                column: "FloorNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectPlacement_ObjectTypeId",
                schema: "Visuals",
                table: "ObjectPlacement",
                column: "ObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectPlacement_RoomId",
                schema: "Visuals",
                table: "ObjectPlacement",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerId",
                schema: "Business",
                table: "Reservation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_EmployeeId",
                schema: "Business",
                table: "Reservation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RoomId",
                schema: "Business",
                table: "Reservation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_StatusId",
                schema: "Business",
                table: "Reservation",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReservationId",
                schema: "Business",
                table: "Review",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_StatusId",
                schema: "Rooms",
                table: "Room",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_TypeId",
                schema: "Rooms",
                table: "Room",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                schema: "Users",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleaningHistory",
                schema: "Rooms");

            migrationBuilder.DropTable(
                name: "CleaningSchedule",
                schema: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotel",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "ObjectPlacement",
                schema: "Visuals");

            migrationBuilder.DropTable(
                name: "Review",
                schema: "Business");

            migrationBuilder.DropTable(
                name: "FloorSchema",
                schema: "Visuals");

            migrationBuilder.DropTable(
                name: "ObjectType",
                schema: "Visuals");

            migrationBuilder.DropTable(
                name: "Reservation",
                schema: "Business");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "Room",
                schema: "Rooms");

            migrationBuilder.DropTable(
                name: "ReservationStatus",
                schema: "Business");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "RoomStatus",
                schema: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomType",
                schema: "Rooms");
        }
    }
}
