CREATE TABLE [dbo].[tblUserPermission] (
    [ID]       INT IDENTITY (1, 1) NOT NULL,
    [ModuleID] INT NULL,
    [RoleID]   INT NULL,
    CONSTRAINT [PK_tblUserPermission] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_tblUserPermission_tblModule] FOREIGN KEY ([ModuleID]) REFERENCES [dbo].[tblModule] ([ID]),
    CONSTRAINT [FK_tblUserPermission_tblRole] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[tblRole] ([ID])
);

