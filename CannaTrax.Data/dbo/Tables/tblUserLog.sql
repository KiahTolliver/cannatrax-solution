CREATE TABLE [dbo].[tblUserLog] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [UserID]    INT            NULL,
    [Message]   NVARCHAR (512) NULL,
    [MoreInfo]  NVARCHAR (512) NULL,
    [LogTime]   DATETIME       NULL,
    [IPAddress] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_tblUserLog] PRIMARY KEY CLUSTERED ([ID] ASC)
);

