CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [Address1] VARCHAR(50) NOT NULL, 
    [Address2] VARCHAR(50) NULL, 
    [City] VARCHAR(50) NULL, 
    [State] VARCHAR(50) NULL, 
    [PostalCode] VARCHAR(50) NULL, 
    [Country] VARCHAR(50) NULL
)
