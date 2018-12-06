CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(200) NOT NULL, 
    [Weight] VARCHAR(200) NULL, 
    [Age] INT NULL, 
    [IgnoredProperty] INT NOT NULL DEFAULT 1
)
