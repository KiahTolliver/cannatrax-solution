CREATE TABLE [dbo].[tblRole] (
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50) NULL,
    [IsDeleted]        BIT           NULL,
    [IsDefault]        BIT           NULL,
    [IsSuperAdmin]     BIT           NULL,
    [InsertedBy]       INT           NULL,
    [InsertedDate]     DATETIME      NULL,
    [LastModifiedBy]   INT           NULL,
    [LastModifiedDate] DATETIME      NULL,
    CONSTRAINT [PK_tblRole] PRIMARY KEY CLUSTERED ([ID] ASC)
);

