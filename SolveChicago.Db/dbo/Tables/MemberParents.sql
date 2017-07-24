﻿CREATE TABLE [dbo].[MemberParents]
(
    [ParentId] INT NOT NULL, 
    [ChildId] INT NOT NULL, 
    [IsBiological] BIT NOT NULL DEFAULT 1, 

    PRIMARY KEY ([ParentId], [ChildId]), 
    CONSTRAINT [FK_MemberParents_Parent] FOREIGN KEY (ParentId) REFERENCES [Members]([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MemberParents_Child] FOREIGN KEY ([ChildId]) REFERENCES [Members]([Id]) ON DELETE NO ACTION,
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'Maps Members to Members, creates a vertical family hierarchy', 'SCHEMA', N'dbo', 'TABLE', N'MemberParents', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'1 = Biological, 0 = Adopted', 'SCHEMA', N'dbo', 'TABLE', N'MemberParents', 'COLUMN', N'IsBiological'
