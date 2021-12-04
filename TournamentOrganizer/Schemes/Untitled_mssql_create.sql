CREATE TABLE [Player] (
	Id integer NOT NULL,
	FirstName varchar(25) NOT NULL,
	LastName varchar(25) NOT NULL,
	NickName varchar(25) NOT NULL UNIQUE,
	TeamId integer,
  CONSTRAINT [PK_PLAYER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Team] (
	Id integer NOT NULL,
	TeamName varchar(25) NOT NULL UNIQUE,
  CONSTRAINT [PK_TEAM] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Game] (
	Id integer NOT NULL,
	GameName varchar(25) NOT NULL UNIQUE,
  CONSTRAINT [PK_GAME] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [RatingPlayer] (
	Id integer NOT NULL,
	CountWins integer NOT NULL,
	CountDraws integer NOT NULL,
	CountDefeats integer NOT NULL,
	PlayerId integer NOT NULL,
	GameId integer NOT NULL,
  CONSTRAINT [PK_RATINGPLAYER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [RatingTeam] (
	Id integer NOT NULL,
	CountWins integer NOT NULL,
	CountDraws integer NOT NULL,
	CountDeteats integer NOT NULL,
	TeamId integer NOT NULL,
	GameId integer NOT NULL,
  CONSTRAINT [PK_RATINGTEAM] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Tournaments] (
	Id integer NOT NULL,
	TournamentName varchar(25) NOT NULL,
	TournamentStartDate datetime NOT NULL,
	TournamentEndDate datetime NOT NULL,
	GameId integer NOT NULL,
  CONSTRAINT [PK_TOURNAMENTS] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [PlayerTournamentsHistory] (
	TournamentId integer NOT NULL,
	PlayerId integer NOT NULL
)
GO
CREATE TABLE [TeamTournamentsHistory] (
	TournamentId integer NOT NULL,
	TeamId integer NOT NULL
)
GO
CREATE TABLE [ResultTournamentPlayer] (
	PlayerId integer NOT NULL,
	Result integer(1) NOT NULL,
	NumberRound integer(2) NOT NULL,
	NumberGame integer(2) NOT NULL,
	TournamentId integer NOT NULL
)
GO
CREATE TABLE [ResultTournamentTeam] (
	TeamId integer NOT NULL,
	Result integer(1) NOT NULL,
	NumberRound integer(2) NOT NULL,
	NumberGame integer(2) NOT NULL,
	TournamentId integer NOT NULL
)
GO
ALTER TABLE [Player] WITH CHECK ADD CONSTRAINT [Player_fk0] FOREIGN KEY ([TeamId]) REFERENCES [Team]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Player] CHECK CONSTRAINT [Player_fk0]
GO



ALTER TABLE [RatingPlayer] WITH CHECK ADD CONSTRAINT [RatingPlayer_fk0] FOREIGN KEY ([PlayerId]) REFERENCES [Player]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [RatingPlayer] CHECK CONSTRAINT [RatingPlayer_fk0]
GO
ALTER TABLE [RatingPlayer] WITH CHECK ADD CONSTRAINT [RatingPlayer_fk1] FOREIGN KEY ([GameId]) REFERENCES [Game]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [RatingPlayer] CHECK CONSTRAINT [RatingPlayer_fk1]
GO

ALTER TABLE [RatingTeam] WITH CHECK ADD CONSTRAINT [RatingTeam_fk0] FOREIGN KEY ([TeamId]) REFERENCES [Team]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [RatingTeam] CHECK CONSTRAINT [RatingTeam_fk0]
GO
ALTER TABLE [RatingTeam] WITH CHECK ADD CONSTRAINT [RatingTeam_fk1] FOREIGN KEY ([GameId]) REFERENCES [Game]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [RatingTeam] CHECK CONSTRAINT [RatingTeam_fk1]
GO

ALTER TABLE [Tournaments] WITH CHECK ADD CONSTRAINT [Tournaments_fk0] FOREIGN KEY ([GameId]) REFERENCES [Game]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Tournaments] CHECK CONSTRAINT [Tournaments_fk0]
GO

ALTER TABLE [PlayerTournamentsHistory] WITH CHECK ADD CONSTRAINT [PlayerTournamentsHistory_fk0] FOREIGN KEY ([TournamentId]) REFERENCES [Tournaments]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [PlayerTournamentsHistory] CHECK CONSTRAINT [PlayerTournamentsHistory_fk0]
GO
ALTER TABLE [PlayerTournamentsHistory] WITH CHECK ADD CONSTRAINT [PlayerTournamentsHistory_fk1] FOREIGN KEY ([PlayerId]) REFERENCES [Player]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [PlayerTournamentsHistory] CHECK CONSTRAINT [PlayerTournamentsHistory_fk1]
GO

ALTER TABLE [TeamTournamentsHistory] WITH CHECK ADD CONSTRAINT [TeamTournamentsHistory_fk0] FOREIGN KEY ([TournamentId]) REFERENCES [Tournaments]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TeamTournamentsHistory] CHECK CONSTRAINT [TeamTournamentsHistory_fk0]
GO
ALTER TABLE [TeamTournamentsHistory] WITH CHECK ADD CONSTRAINT [TeamTournamentsHistory_fk1] FOREIGN KEY ([TeamId]) REFERENCES [Team]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TeamTournamentsHistory] CHECK CONSTRAINT [TeamTournamentsHistory_fk1]
GO

ALTER TABLE [ResultTournamentPlayer] WITH CHECK ADD CONSTRAINT [ResultTournamentPlayer_fk0] FOREIGN KEY ([PlayerId]) REFERENCES [Player]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [ResultTournamentPlayer] CHECK CONSTRAINT [ResultTournamentPlayer_fk0]
GO
ALTER TABLE [ResultTournamentPlayer] WITH CHECK ADD CONSTRAINT [ResultTournamentPlayer_fk1] FOREIGN KEY ([TournamentId]) REFERENCES [Tournaments]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [ResultTournamentPlayer] CHECK CONSTRAINT [ResultTournamentPlayer_fk1]
GO

ALTER TABLE [ResultTournamentTeam] WITH CHECK ADD CONSTRAINT [ResultTournamentTeam_fk0] FOREIGN KEY ([TeamId]) REFERENCES [Team]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [ResultTournamentTeam] CHECK CONSTRAINT [ResultTournamentTeam_fk0]
GO
ALTER TABLE [ResultTournamentTeam] WITH CHECK ADD CONSTRAINT [ResultTournamentTeam_fk1] FOREIGN KEY ([TournamentId]) REFERENCES [Tournaments]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [ResultTournamentTeam] CHECK CONSTRAINT [ResultTournamentTeam_fk1]
GO

