﻿CREATE TABLE [dbo].[Admins]
(
	[Id] INT IDENTITY(1, 1) NOT NULL,
    [Email] NVARCHAR(128) NOT NULL, 
	[FirstName] NVARCHAR(128) NULL, 
	[LastName] NVARCHAR(128) NULL, 
    [ProfilePicturePath] NVARCHAR(128) NULL, 
    [CreatedDate] DATETIME2 NULL, 
	[InvitedBy] NVARCHAR(50) NULL, 
    [UserId] NVARCHAR(128) NOT NULL,
	
    CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Admin_AspNetUser] FOREIGN KEY (UserId) REFERENCES [AspNetUsers](Id) ON DELETE CASCADE, 
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'Stores information about Admins', 'SCHEMA', N'dbo', 'TABLE', N'Admins', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'UserId of inviting Admin', 'SCHEMA', N'dbo', 'TABLE', N'Admins', 'COLUMN', N'InvitedBy'
