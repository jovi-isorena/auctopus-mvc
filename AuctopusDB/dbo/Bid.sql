CREATE TABLE [dbo].[Bid]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ItemId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Amount] DECIMAL(18, 2) NOT NULL, 
    [Status] NVARCHAR(20) NOT NULL,
	FOREIGN KEY (ItemId) REFERENCES [AuctionedItem] ( AuctionedItemId ),
	FOREIGN KEY (UserId) REFERENCES [User] ( Id )
);
