CREATE TABLE [dbo].[tblCategory] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (512) NULL,
    [IsDeleted]        BIT            NULL,
    [InsertedBy]       INT            NULL,
    [InsertedDate]     DATETIME       NULL,
    [LastModifiedBy]   INT            NULL,
    [LastModifiedDate] DATETIME       NULL,
    CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED ([ID] ASC)
);

