﻿CREATE TABLE [dbo].[MemberCorporations]
(
	[MemberId] INT NOT NULL, 
    [CorporationId] INT NOT NULL, 

	PRIMARY KEY([MemberId], [CorporationId]),
    CONSTRAINT [FK_MemberCorporations_Members] FOREIGN KEY (MemberId) REFERENCES [Members](Id) ON DELETE CASCADE, 
    CONSTRAINT [FK_MemberCorporations_Corporations] FOREIGN KEY (CorporationId) REFERENCES [Corporations]([Id]) ON DELETE CASCADE
)
