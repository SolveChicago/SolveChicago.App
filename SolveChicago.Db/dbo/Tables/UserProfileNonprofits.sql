﻿CREATE TABLE [dbo].[UserProfileNonprofits]
(
	[UserId] NVARCHAR(128)  NOT NULL, 
    [NonprofitId] INT NOT NULL,

	PRIMARY KEY ([NonprofitId], [UserId]), 
    CONSTRAINT [FK_UserProfileNonprofits_AspNetUser] FOREIGN KEY (UserId) REFERENCES [AspNetUsers](Id) ON DELETE CASCADE, 
    CONSTRAINT [FK_UserProfileNonprofits_Nonprofit] FOREIGN KEY (NonprofitId) REFERENCES [Nonprofits]([Id]) ON DELETE CASCADE
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'Maps AspNetUsers to Nonprofits', 'SCHEMA', N'dbo', 'TABLE', N'UserProfileNonprofits', NULL, NULL