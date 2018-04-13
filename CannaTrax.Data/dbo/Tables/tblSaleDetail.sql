CREATE TABLE [dbo].[tblSaleDetail] (
    [ID]           INT             IDENTITY (1, 1) NOT NULL,
    [SaleID]       INT             NULL,
    [ItemID]       INT             NULL,
    [Quantity]     INT             NULL,
    [UnitPrice]    DECIMAL (18, 2) NULL,
    [SellPrice]    DECIMAL (18, 2) NULL,
    [DiscountRate] DECIMAL (18, 2) NULL,
    [Discount]     DECIMAL (18, 2) NULL,
    [NetAmount]    DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_tblSaleDetail] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_tblSaleDetail_tblItem] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[tblItem] ([ID]),
    CONSTRAINT [FK_tblSaleDetail_tblSale] FOREIGN KEY ([SaleID]) REFERENCES [dbo].[tblSale] ([ID])
);

