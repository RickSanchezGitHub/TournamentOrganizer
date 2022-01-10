CREATE TABLE [dbo].[Team_Player](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NOT NULL,
	[PlayerId] [int] NOT NULL,
 CONSTRAINT [PK_Team_Player] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
),UNIQUE NONCLUSTERED 
(
	[TeamId] ASC,
	[PlayerId] ASC
)
) 
GO

ALTER TABLE [dbo].[Team_Player]  WITH CHECK ADD  CONSTRAINT [FK_Team_Player_Player] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[Player] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Team_Player] CHECK CONSTRAINT [FK_Team_Player_Player]
GO

ALTER TABLE [dbo].[Team_Player]  WITH CHECK ADD  CONSTRAINT [FK_Team_Player_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Team_Player] CHECK CONSTRAINT [FK_Team_Player_Team]
GO