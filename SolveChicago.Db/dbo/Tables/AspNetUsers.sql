﻿CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [ReceiveEmail] BIT NULL, 
    [LastActivityDate] DATETIME2 NOT NULL DEFAULT ((GETDATE())), 
    [UserName]                NVARCHAR (256) NULL,
    [FirstName] NVARCHAR(128) NULL, 
	[LastName] NVARCHAR(128) NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT ((GETDATE())), 
    CONSTRAINT [PK_AspNetUser] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);
GO

