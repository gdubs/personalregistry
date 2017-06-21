use Wedding

CREATE TABLE [dbo].[Addresses]
(
	[Id] INT Identity (1, 1) NOT NULL PRIMARY KEY,
    [Address1] VARCHAR(50) NOT NULL, 
    [Address2] VARCHAR(50) NULL, 
    [City] VARCHAR(50) NULL, 
    [State] VARCHAR(50) NULL, 
    [PostalCode] VARCHAR(50) NULL, 
    [Country] VARCHAR(50) NULL
)

CREATE TABLE [dbo].[Events]
(
	[Id] INT Identity (1, 1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Date] DATE NOT NULL, 
    [EndRegistration] DATE NULL, 
    [AddressId] INT NULL references Addresses (Id)
)

CREATE TABLE [dbo].[Guests]
(
	[Id] INT Identity (1, 1) NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NULL, 
    [AdditionalGuest] INT NOT NULL,
	[ConfirmedGuests] INT NOT NULL, 
    [Code] VARCHAR(50) NULL, 
    [RSVPDate] DATE NULL, 
	[Note] VARCHAR(50) NULL,		-- dietary restrictions
    [EventId] INT NOT NULL references Events (Id),
	[ParentId] INT NULL,
	[AddressId] INT NULL references Addresses (Id),
	[Attending] bit not null default 0,
	Constraint FK_Guest_ParentId Foreign Key (ParentId) references Guests (Id)
)

CREATE TABLE [dbo].[Interests]
(
	[Id] INT Identity (1, 1) NOT NULL PRIMARY KEY, 
    [Email] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(250) NULL,
)



select * from Guests