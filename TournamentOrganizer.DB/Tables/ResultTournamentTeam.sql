CREATE TABLE [dbo].[ResultTournamentTeam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NOT NULL,
	[Result] [int] NOT NULL,
	[NumberRound] [int] NOT NULL,
	[NumberMatch] [int] NOT NULL,
	[TournamentId] [int] NOT NULL,
 CONSTRAINT [PK_RESULTTOURNAMENTTEAM] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ResultTournamentTeam]  WITH CHECK ADD  CONSTRAINT [ResultTournamentTeam_fk0] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[ResultTournamentTeam] CHECK CONSTRAINT [ResultTournamentTeam_fk0]
GO

ALTER TABLE [dbo].[ResultTournamentTeam]  WITH CHECK ADD  CONSTRAINT [ResultTournamentTeam_fk1] FOREIGN KEY([TournamentId])
REFERENCES [dbo].[Tournament] ([Id])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[ResultTournamentTeam] CHECK CONSTRAINT [ResultTournamentTeam_fk1]
GO

