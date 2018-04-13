CREATE TABLE [dbo].[tblShop] (
    [ID]               INT             IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (512)  NULL,
    [StoreCode]        NVARCHAR (50)   NULL,
    [Address]          NVARCHAR (1000) NULL,
    [PhoneNo]          NVARCHAR (50)   NULL,
    [Email]            NVARCHAR (512)  NULL,
    [LogoPath]         NVARCHAR (512)  NULL,
    [IsDeleted]        BIT             NULL,
    [IsDefault]        BIT             NULL,
    [InsertedBy]       INT             NULL,
    [InsertedDate]     DATETIME        NULL,
    [LastModifiedBy]   INT             NULL,
    [LastModifiedDate] DATETIME        NULL,
    CONSTRAINT [PK_tblShop] PRIMARY KEY CLUSTERED ([ID] ASC)
);

