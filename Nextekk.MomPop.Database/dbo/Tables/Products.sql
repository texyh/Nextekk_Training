CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(256) NOT NULL, 
    [Description] NVARCHAR(1000) NOT NULL, 
    [Stock] INT NOT NULL, 
    [Price] MONEY NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT sysutcdatetime(), 
    [UpdatedAt] DATETIME2 NOT NULL DEFAULT sysutcdatetime()
)
