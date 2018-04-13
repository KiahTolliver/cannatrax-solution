CREATE TABLE [dbo].[tblItem] (
    [ID]               INT             IDENTITY (1, 1) NOT NULL,
    [ItemCode]         NVARCHAR (50)   NULL,
    [Name]             NVARCHAR (512)  NULL,
    [CategoryID]       INT             NULL,
    [PurchasePrice]    DECIMAL (18, 2) NULL,
    [SellingPrice]     DECIMAL (18, 2) NULL,
    [DiscountRate]     DECIMAL (18, 2) NULL,
    [Quantity]         DECIMAL (18, 3) NULL,
    [PhotoPath]        NVARCHAR (512)  NULL,
    [IsDeleted]        BIT             NULL,
    [InsertedBy]       INT             NULL,
    [InsertedDate]     DATETIME        NULL,
    [LastModifiedBy]   INT             NULL,
    [LastModifiedDate] DATETIME        NULL,
    CONSTRAINT [PK_tblItem] PRIMARY KEY CLUSTERED ([ID] ASC)
);

