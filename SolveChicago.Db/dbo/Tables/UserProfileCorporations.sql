﻿CREATE TABLE [dbo].[UserProfileCorporations]
(
	[UserId] NVARCHAR(128)  NOT NULL, 
    [CorporationId] INT NOT NULL,

	PRIMARY KEY ([CorporationId], [UserId]), 
    CONSTRAINT [FK_UserProfileCorporations_AspNetUser] FOREIGN KEY (UserId) REFERENCES [AspNetUsers](Id) ON DELETE CASCADE, 
    CONSTRAINT [FK_UserProfileCorporations_Corporation] FOREIGN KEY (CorporationId) REFERENCES [Corporations]([Id]) ON DELETE CASCADE
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'Maps AspNetUsers to Corporations', 'SCHEMA', N'dbo', 'TABLE', N'UserProfileCorporations', NULL, NULL