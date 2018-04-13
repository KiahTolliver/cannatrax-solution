CREATE TABLE [dbo].[tblCustomer] (
    [ID]               INT             IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (512)  NULL,
    [PhoneNo]          NVARCHAR (50)   NULL,
    [Email]            NVARCHAR (512)  NULL,
    [Address]          NVARCHAR (1000) NULL,
    [IsDeleted]        BIT             NULL,
    [IsActive]         BIT             NULL,
    [InsertedBy]       INT             NULL,
    [InsertedDate]     DATETIME        NULL,
    [LastModifiedBy]   INT             NULL,
    [LastModifiedDate] DATETIME        NULL,
    CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED ([ID] ASC)
);

