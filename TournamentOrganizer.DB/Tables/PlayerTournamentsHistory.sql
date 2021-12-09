CREATE TABLE [PlayerTournamentsHistory] (
	Id integer NOT NULL,
	TournamentId integer NOT NULL,
	PlayerId integer NOT NULL,
  CONSTRAINT [PK_PLAYERTOURNAMENTSHISTORY] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF), 
    CONSTRAINT [FK_PlayerTournamentsHistory_ToTable] FOREIGN KEY ([TournamentId]) REFERENCES [Tournament]([Id])

)
