﻿CREATE TABLE [dbo].[UserIpAddresses]
(
	[UserId] NVARCHAR(128) NOT NULL, 
    [IpAddressId] INT NOT NULL, 
    [Date] DATETIME2 NOT NULL

	PRIMARY KEY ([UserId], [IpAddressId], [Date]), 
	CONSTRAINT [FK_UserIpAddresses_AspNetUser] FOREIGN KEY (UserId) REFERENCES [AspNetUsers](Id) ON DELETE CASCADE, 
	CONSTRAINT [FK_UserIpAddresses_IpAddress] FOREIGN KEY (IpAddressId) REFERENCES [IpAddresses](Id) ON DELETE CASCADE, 
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'Maps AspNetUsers to IpAddresses', 'SCHEMA', N'dbo', 'TABLE', N'UserIpAddresses', NULL, NULL