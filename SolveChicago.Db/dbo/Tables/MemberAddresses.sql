﻿CREATE TABLE [dbo].[MemberAddresses]
(
	[AddressId] INT NOT NULL, 
    [MemberId] INT NOT NULL,

    PRIMARY KEY ([AddressId], [MemberId]), 
    CONSTRAINT [FK_MemberAddresses_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [Addresses]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MemberAddresses_Members] FOREIGN KEY ([MemberId]) REFERENCES [Members]([Id]) ON DELETE CASCADE,
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'Maps Members to Addresses', 'SCHEMA', N'dbo', 'TABLE', N'MemberAddresses', NULL, NULL

