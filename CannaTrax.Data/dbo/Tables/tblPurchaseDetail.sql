CREATE TABLE [dbo].[tblPurchaseDetail] (
    [ID]         INT             IDENTITY (1, 1) NOT NULL,
    [PurchaseID] INT             NULL,
    [ItemID]     INT             NULL,
    [Quantity]   DECIMAL (18)    NULL,
    [Price]      DECIMAL (18, 2) NULL,
    [Discount]   DECIMAL (18, 2) NULL,
    [Amount]     DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_tblPurchaseDetail] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_tblPurchaseDetail_tblItem] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[tblItem] ([ID]),
    CONSTRAINT [FK_tblPurchaseDetail_tblPurchase] FOREIGN KEY ([PurchaseID]) REFERENCES [dbo].[tblPurchase] ([ID])
);

