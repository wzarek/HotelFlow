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
  [Name] nvarchar NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Users].[User] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [RoleId] int NOT NULL,
  [UserName] nvarchar NOT NULL,
  [Password] nvarchar NOT NULL,
  [Name] nvarchar NOT NULL,
  [Surname] nvarchar NOT NULL,
  [AddressLine1] nvarchar,
  [AddressLine2] nvarchar,
  [PhoneNumber] nvarchar,
  [EmailAddress] nvarchar NOT NULL,
  [IsActive] bit NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Rooms].[RoomType] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [Name] nvarchar NOT NULL,
  [NumberOfPeople] int NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Rooms].[RoomStatus] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [Name] nvarchar NOT NULL,
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
  [Name] nvarchar NOT NULL,
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
  [Comment] nvarchar NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Base].[Hotel] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [Name] nvarchar NOT NULL,
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
  [Type] nvarchar NOT NULL,
  [DateCreated] datetime NOT NULL
)
GO

CREATE TABLE [Visuals].[ObjectPlacement] (
  [Id] int PRIMARY KEY IDENTITY(1,1),
  [ObjectTypeId] int NOT NULL,
  [FloorNumberId] int NOT NULL,
  [PositionFrom] nvarchar NOT NULL,
  [PositionTo] nvarchar NOT NULL,
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
