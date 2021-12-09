CREATE TABLE [TeamTournamentsHistory] (
	Id integer NOT NULL,
	TournamentId integer NOT NULL,
	TeamId integer NOT NULL,
  CONSTRAINT [PK_TEAMTOURNAMENTSHISTORY] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF), 
    CONSTRAINT [FK_TeamTournamentsHistory_ToTable] FOREIGN KEY ([TournamentId]) REFERENCES [Tournament]([id])

)
