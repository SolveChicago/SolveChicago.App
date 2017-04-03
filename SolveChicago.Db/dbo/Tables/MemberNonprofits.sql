﻿CREATE TABLE [dbo].[MemberNonprofits]
(
	[MemberId] INT NOT NULL, 
    [NonprofitId] INT NOT NULL, 
    [CaseManagerId] INT NULL, 
	[MemberEnjoyed] NVARCHAR(MAX) NULL, 
    [MemberStruggled] NVARCHAR(MAX) NULL, 

    PRIMARY KEY([MemberId], [NonprofitId]),
    CONSTRAINT [FK_MemberNonprofits_Members] FOREIGN KEY (MemberId) REFERENCES [Members](Id) ON DELETE CASCADE, 
    CONSTRAINT [FK_MemberNonprofits_Nonprofits] FOREIGN KEY (NonprofitId) REFERENCES [Nonprofits]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MemberNonprofits_CaseManagers] FOREIGN KEY (CaseManagerId) REFERENCES [CaseManagers]([Id]) ON DELETE SET NULL
)
