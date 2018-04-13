CREATE TABLE [dbo].[tblModule] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [ParentModuleID] INT            NULL,
    [DisplayOrder]   INT            NULL,
    [ModuleName]     NVARCHAR (100) NULL,
    [PageIcon]       NVARCHAR (50)  NULL,
    [PageUrl]        NVARCHAR (100) NULL,
    [PageSlug]       NVARCHAR (512) NULL,
    [IsShow]         BIT            NULL,
    [IsDeleted]      BIT            NULL,
    [IsActive]       BIT            NULL,
    CONSTRAINT [PK_tblModule] PRIMARY KEY CLUSTERED ([ID] ASC)
);

