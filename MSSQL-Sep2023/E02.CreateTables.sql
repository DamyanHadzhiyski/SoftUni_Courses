USE [Minions]

CREATE TABLE [Minions]
	([Id] INT PRIMARY KEY,
	[Name] NVARCHAR(30) NULL,
	[Age] INT NULL)

CREATE TABLE [Towns]
	([Id] INT PRIMARY KEY,
	[Name] NVARCHAR(30) NULL)