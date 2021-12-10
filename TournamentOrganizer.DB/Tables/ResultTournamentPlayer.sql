CREATE TABLE [dbo].[ResultTournamentPlayer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlayerId] [int] NOT NULL,
	[Result] [int] NOT NULL,
	[NumberRound] [int] NOT NULL,
	[NumberGame] [int] NOT NULL,
	[TournamentId] [int] NOT NULL,
 CONSTRAINT [PK_RESULTTOURNAMENTPLAYER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ResultTournamentPlayer]  WITH CHECK ADD  CONSTRAINT [ResultTournamentPlayer_fk0] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[Player] ([Id])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[ResultTournamentPlayer] CHECK CONSTRAINT [ResultTournamentPlayer_fk0]
GO

ALTER TABLE [dbo].[ResultTournamentPlayer]  WITH CHECK ADD  CONSTRAINT [ResultTournamentPlayer_fk1] FOREIGN KEY([TournamentId])
REFERENCES [dbo].[Tournament] ([Id])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[ResultTournamentPlayer] CHECK CONSTRAINT [ResultTournamentPlayer_fk1]
GO
