CREATE SCHEMA [Users]
GO

CREATE SCHEMA [Rooms]
GO

CREATE SCHEMA [Business]
GO

CREATE SCHEMA [Base]
GO

CREATE SCHEMA [Visuals]
GO

CREATE TABLE [Users].[Role] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [Name] nvarchar(255) NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Users].[User] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [RoleId] int NOT NULL,
  [UserName] nvarchar(255) NOT NULL,
  [Password] nvarchar(255) NOT NULL,
  [Name] nvarchar(255) NOT NULL,
  [Surname] nvarchar(255) NOT NULL,
  [AddressLine1] nvarchar(255),
  [AddressLine2] nvarchar(255),
  [PhoneNumber] nvarchar(255),
  [EmailAddress] nvarchar(255) NOT NULL,
  [IsActive] bit NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Rooms].[RoomType] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [Name] nvarchar(255) NOT NULL,
  [NumberOfPeople] int NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Rooms].[RoomStatus] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [Name] nvarchar(255) NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Rooms].[Room] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [Number] int NOT NULL,
  [TypeId] int NOT NULL,
  [StatusId] int NOT NULL,
  [IsActive] bit NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Rooms].[CleaningSchedule] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [RoomId] int NOT NULL,
  [EmployeeId] int NOT NULL,
  [DateToBeCleaned] datetime NOT NULL
)
GO

CREATE TABLE [Rooms].[CleaningHistory] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [RoomId] int NOT NULL,
  [EmployeeId] int NOT NULL,
  [DateCleaned] datetime NOT NULL
)
GO

CREATE TABLE [Business].[ReservationStatus] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [Name] nvarchar(255) NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Business].[Reservation] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [CustomerId] int NOT NULL,
  [EmployeeId] int NOT NULL,
  [RoomId] int NOT NULL,
  [DateFrom] smalldatetime NOT NULL,
  [DateTo] smalldatetime NOT NULL,
  [StatusId] int NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Business].[Review] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [ReservationId] int NOT NULL,
  [Rating] int NOT NULL,
  [Comment] nvarchar(255) NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Base].[Hotel] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [Name] nvarchar(255) NOT NULL,
  [CheckInTime] time NOT NULL,
  [CheckOutTime] time NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Visuals].[FloorSchema] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [FloorNumber] int UNIQUE NOT NULL,
  [Width] int NOT NULL,
  [Height] int NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Visuals].[ObjectType] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [Type] nvarchar(255) NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Visuals].[ObjectPlacement] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [ObjectTypeId] int NOT NULL,
  [FloorNumberId] int NOT NULL,
  [PositionFrom] nvarchar(255) NOT NULL,
  [PositionTo] nvarchar(255) NOT NULL,
  [RoomId] int,
  [DateCreated] datetime NOT NULL
)
GO

ALTER TABLE [Users].[User] ADD FOREIGN KEY ([RoleId]) REFERENCES [Users].[Role] ([Id])
GO

ALTER TABLE [Rooms].[Room] ADD FOREIGN KEY ([TypeId]) REFERENCES [Rooms].[RoomType] ([Id])
GO

ALTER TABLE [Rooms].[Room] ADD FOREIGN KEY ([StatusId]) REFERENCES [Rooms].[RoomStatus] ([Id])
GO

ALTER TABLE [Rooms].[CleaningSchedule] ADD FOREIGN KEY ([RoomId]) REFERENCES [Rooms].[Room] ([Id])
GO

ALTER TABLE [Rooms].[CleaningSchedule] ADD FOREIGN KEY ([EmployeeId]) REFERENCES [Users].[User] ([Id])
GO

ALTER TABLE [Rooms].[CleaningHistory] ADD FOREIGN KEY ([RoomId]) REFERENCES [Rooms].[Room] ([Id])
GO

ALTER TABLE [Rooms].[CleaningHistory] ADD FOREIGN KEY ([EmployeeId]) REFERENCES [Users].[User] ([Id])
GO

ALTER TABLE [Business].[Reservation] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Users].[User] ([Id])
GO

ALTER TABLE [Business].[Reservation] ADD FOREIGN KEY ([EmployeeId]) REFERENCES [Users].[User] ([Id])
GO

ALTER TABLE [Business].[Reservation] ADD FOREIGN KEY ([RoomId]) REFERENCES [Rooms].[Room] ([Id])
GO

ALTER TABLE [Business].[Reservation] ADD FOREIGN KEY ([StatusId]) REFERENCES [Business].[ReservationStatus] ([Id])
GO

ALTER TABLE [Business].[Review] ADD FOREIGN KEY ([ReservationId]) REFERENCES [Business].[Reservation] ([Id])
GO

ALTER TABLE [Visuals].[ObjectPlacement] ADD FOREIGN KEY ([ObjectTypeId]) REFERENCES [Visuals].[ObjectType] ([Id])
GO

ALTER TABLE [Visuals].[ObjectPlacement] ADD FOREIGN KEY ([FloorNumberId]) REFERENCES [Visuals].[FloorSchema] ([Id])
GO

ALTER TABLE [Visuals].[ObjectPlacement] ADD FOREIGN KEY ([RoomId]) REFERENCES [Rooms].[Room] ([Id])
GO

insert into Users.Role (Name, DateCreated)
values ('Admin', GETDATE()),
('Employee', GETDATE()),
('User', GETDATE()),
('Guest', GETDATE())
