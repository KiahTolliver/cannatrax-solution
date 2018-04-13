CREATE TABLE [dbo].[tblGeneralSetting] (
    [ID]           INT             IDENTITY (1, 1) NOT NULL,
    [CompanyName]  NVARCHAR (512)  NULL,
    [Address]      NVARCHAR (1000) NULL,
    [PhoneNo]      NVARCHAR (512)  NULL,
    [Email]        NVARCHAR (52)   NULL,
    [Website]      NVARCHAR (512)  NULL,
    [CompanyLogo]  NVARCHAR (512)  NULL,
    [CurrencyCode] NVARCHAR (50)   NULL,
    CONSTRAINT [PK_GeneralSetting] PRIMARY KEY CLUSTERED ([ID] ASC)
);

