CREATE DATABASE [SoftUni]
GO

USE [SoftUni]
GO

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)
GO

CREATE TABLE [Addresses] (
	[Id] INT PRIMARY KEY IDENTITY,
	[AddressText] NVARCHAR(100) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns](Id)
)
GO

CREATE TABLE [Departments] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)
GO

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[MiddleName] NVARCHAR(30) NULL,
	[LastName] NVARCHAR(60) NOT NULL,
	[JobTitle] NVARCHAR(60) NOT NULL, 
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments](Id), 
	[HireDate] DATETIME2 NOT NULL, 
	[Salary] DECIMAL(7,2) NOT NULL, 
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id)
)
GO