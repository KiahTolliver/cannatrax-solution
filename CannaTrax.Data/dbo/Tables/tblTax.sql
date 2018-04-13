CREATE TABLE [dbo].[tblTax] (
    [ID]               INT             IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50)   NULL,
    [TaxRate]          DECIMAL (18, 2) NULL,
    [IsDeleted]        BIT             NULL,
    [IsActive]         BIT             NULL,
    [InsertedBy]       INT             NULL,
    [InsertedDate]     DATETIME        NULL,
    [LastModifiedBy]   INT             NULL,
    [LastModifiedDate] DATETIME        NULL,
    CONSTRAINT [PK_tblTax] PRIMARY KEY CLUSTERED ([ID] ASC)
);

