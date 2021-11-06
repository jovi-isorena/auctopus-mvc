CREATE TABLE [dbo].[WonItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ItemId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL,
	FOREIGN KEY (ItemId) REFERENCES [AuctionedItem] ([AuctionedItemId]),
	FOREIGN KEY (UserId) REFERENCES [User] (Id)
)
