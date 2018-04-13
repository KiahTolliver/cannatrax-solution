CREATE TABLE [dbo].[tblSupplier] (
    [ID]               INT             IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (512)  NULL,
    [CompanyName]      NVARCHAR (512)  NULL,
    [PhoneNo]          NVARCHAR (100)  NULL,
    [City]             NVARCHAR (50)   NULL,
    [Email]            NVARCHAR (512)  NULL,
    [Address]          NVARCHAR (1000) NULL,
    [SupplierType]     NVARCHAR (50)   NULL,
    [IsDeleted]        BIT             NULL,
    [InsertedBy]       INT             NULL,
    [InsertedDate]     DATETIME        NULL,
    [LastModifiedBy]   INT             NULL,
    [LastModifiedDate] DATETIME        NULL,
    CONSTRAINT [PK_tblSupplier] PRIMARY KEY CLUSTERED ([ID] ASC)
);

