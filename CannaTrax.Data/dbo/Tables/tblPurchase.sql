CREATE TABLE [dbo].[tblPurchase] (
    [ID]               INT             IDENTITY (1, 1) NOT NULL,
    [SupplierID]       INT             NULL,
    [PurchaseDate]     DATETIME        NULL,
    [TotalItem]        DECIMAL (18)    NULL,
    [TotalAmount]      DECIMAL (18, 2) NULL,
    [Payment]          DECIMAL (18, 2) NULL,
    [PaidBy]           NVARCHAR (50)   NULL,
    [Note]             NVARCHAR (512)  NULL,
    [IsDeleted]        BIT             NULL,
    [InsertedBy]       INT             NULL,
    [InsertedDate]     DATETIME        NULL,
    [LastModifiedBy]   INT             NULL,
    [LastModifiedDate] DATETIME        NULL,
    CONSTRAINT [PK_tblPurchase] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_tblPurchase_tblSupplier] FOREIGN KEY ([SupplierID]) REFERENCES [dbo].[tblSupplier] ([ID])
);

