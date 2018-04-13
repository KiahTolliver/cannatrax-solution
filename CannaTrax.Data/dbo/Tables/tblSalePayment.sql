CREATE TABLE [dbo].[tblSalePayment] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [SaleID]      INT             NULL,
    [PaymentDate] DATE            NULL,
    [PaymentMode] NVARCHAR (50)   NULL,
    [Amount]      DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_tblSalePayment] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_tblSalePayment_tblSale] FOREIGN KEY ([SaleID]) REFERENCES [dbo].[tblSale] ([ID])
);

