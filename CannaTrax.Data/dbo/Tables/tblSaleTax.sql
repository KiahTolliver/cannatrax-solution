CREATE TABLE [dbo].[tblSaleTax] (
    [ID]        INT             IDENTITY (1, 1) NOT NULL,
    [SaleID]    INT             NULL,
    [TaxID]     INT             NULL,
    [TaxRate]   DECIMAL (18, 2) NULL,
    [TaxAmount] DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_tblSaleTax] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_tblSaleTax_tblSale] FOREIGN KEY ([SaleID]) REFERENCES [dbo].[tblSale] ([ID]),
    CONSTRAINT [FK_tblSaleTax_tblTax] FOREIGN KEY ([TaxID]) REFERENCES [dbo].[tblTax] ([ID])
);

