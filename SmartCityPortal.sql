USE [master];
GO


CREATE DATABASE [SmartCityPortal]
ON 
(
    NAME = N'SmartCityPortal', 
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SmartCityPortal.mdf', 
    SIZE = 8192KB, 
    MAXSIZE = UNLIMITED, 
    FILEGROWTH = 65536KB
)
LOG ON 
(
    NAME = N'SmartCityPortal_log', 
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SmartCityPortal_log.ldf', 
    SIZE = 8192KB, 
    MAXSIZE = 2048GB, 
    FILEGROWTH = 65536KB
);
GO


USE [SmartCityPortal]
GO


CREATE TABLE [dbo].[Users](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Username] NVARCHAR(50) NOT NULL UNIQUE,
    [PasswordHash] NVARCHAR(255) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL UNIQUE,
    [LastLoginTime] DATETIME NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
    [UpdatedAt] DATETIME NOT NULL DEFAULT GETDATE()
)
GO


CREATE TABLE [dbo].[PublicTransportSchedules](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [StartTime] DATETIME NOT NULL,
    [EndTime] DATETIME NOT NULL,
    [Frequency] INT NOT NULL
)
GO


CREATE TABLE [dbo].[MetroSchedules](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [StartTime] DATETIME NOT NULL,
    [EndTime] DATETIME NOT NULL,
    [Frequency] INT NOT NULL
)
GO


CREATE TABLE [dbo].[WeatherUpdates](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Temperature] FLOAT NOT NULL,
    [Humidity] FLOAT NOT NULL,
    [WeatherDescription] NVARCHAR(255) NOT NULL,
    [Timestamp] DATETIME NOT NULL
)
GO


CREATE TABLE [dbo].[EmergencyServices](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [ServiceName] NVARCHAR(100) NOT NULL,
    [ContactNumber] NVARCHAR(15) NOT NULL,
    [IsActive] BIT NOT NULL
)
GO


CREATE TABLE [dbo].[LocalNews](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Title] NVARCHAR(255) NOT NULL,
    [Content] TEXT NOT NULL,
    [AuthorId] INT NULL,
    [PublishedAt] DATETIME NOT NULL DEFAULT GETDATE(),
    [Image] NVARCHAR(200) NULL,
    FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Users]([Id])
)
GO
