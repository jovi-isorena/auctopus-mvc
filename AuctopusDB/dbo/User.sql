CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] NVARCHAR(255) NOT NULL, 
	[FirstName] NVARCHAR(255) NOT NULL,
	[LastName] NVARCHAR(255) NOT NULL,
    [Password] NVARCHAR(255) NOT NULL, 
    [Bidpoint] DECIMAL(18, 2) NOT NULL DEFAULT 0, 
    [HomeAddress] NVARCHAR(255) NULL, 
    [LastLoginAttempt] DATETIME NULL, 
    [LoginAttemptCount] INT NULL, 
    [LockedUntil] DATETIME NULL, 
    [Status] NVARCHAR(20) NOT NULL,
	
)
