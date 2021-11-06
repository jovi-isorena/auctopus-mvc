CREATE TABLE [dbo].[AuctionedItem] (
    [AuctionedItemId]      INT             IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (255)  NOT NULL,
    [Description]          NVARCHAR (255)  NOT NULL,
	[ImageURL]			   NVARCHAR (255)  NULL,
    [BidMethod]            NVARCHAR (255)  NOT NULL,
    [AuctionStartDateTime] DATETIME        NOT NULL,
    [AuctionEndDateTime]   DATETIME        NOT NULL,
    [InitialBid]           DECIMAL (18, 2) NOT NULL,
    [Status]               NVARCHAR (20)   NOT NULL,
    PRIMARY KEY CLUSTERED ([AuctionedItemId] ASC)
);