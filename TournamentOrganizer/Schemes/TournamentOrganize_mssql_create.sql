CREATE TABLE [Player] (
	Id integer NOT NULL,
	FirstName varchar(25) NOT NULL,
	LastName varchar(25) NOT NULL,
	NickName varchar(25) NOT NULL UNIQUE,
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
	Name varchar(25) NOT NULL UNIQUE,
  CONSTRAINT [PK_GAME] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Tournament] (
	Id integer NOT NULL,
	Name varchar(25) NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NOT NULL,
	GameId integer NOT NULL,
  CONSTRAINT [PK_TOURNAMENT] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [PlayerTournamentsHistory] (
	Id integer NOT NULL,
	TournamentId integer NOT NULL,
	PlayerId integer NOT NULL,
  CONSTRAINT [PK_PLAYERTOURNAMENTSHISTORY] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [TeamTournamentsHistory] (
	Id integer NOT NULL,
	TournamentId integer NOT NULL,
	TeamId integer NOT NULL,
  CONSTRAINT [PK_TEAMTOURNAMENTSHISTORY] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ResultTournamentPlayer] (
	Id integer NOT NULL,
	PlayerId integer NOT NULL,
	Result integer NOT NULL,
	NumberRound integer NOT NULL,
	NumberGame integer NOT NULL,
	TournamentId integer NOT NULL,
  CONSTRAINT [PK_RESULTTOURNAMENTPLAYER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ResultTournamentTeam] (
	Id integer NOT NULL,
	TeamId integer NOT NULL,
	Result integer NOT NULL,
	NumberRound integer NOT NULL,
	NumberGame integer NOT NULL,
	TournamentId integer NOT NULL,
  CONSTRAINT [PK_RESULTTOURNAMENTTEAM] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Team_Player] (
	Id integer NOT NULL,
	TeamId integer NOT NULL,
	PlayerId integer NOT NULL,
  CONSTRAINT [PK_TEAM_PLAYER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO



ALTER TABLE [Tournament] WITH CHECK ADD CONSTRAINT [Tournament_fk0] FOREIGN KEY ([GameId]) REFERENCES [Game]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Tournament] CHECK CONSTRAINT [Tournament_fk0]
GO

ALTER TABLE [PlayerTournamentsHistory] WITH CHECK ADD CONSTRAINT [PlayerTournamentsHistory_fk0] FOREIGN KEY ([TournamentId]) REFERENCES [Tournament]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [PlayerTournamentsHistory] CHECK CONSTRAINT [PlayerTournamentsHistory_fk0]
GO
ALTER TABLE [PlayerTournamentsHistory] WITH CHECK ADD CONSTRAINT [PlayerTournamentsHistory_fk1] FOREIGN KEY ([PlayerId]) REFERENCES [Player]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [PlayerTournamentsHistory] CHECK CONSTRAINT [PlayerTournamentsHistory_fk1]
GO

ALTER TABLE [TeamTournamentsHistory] WITH CHECK ADD CONSTRAINT [TeamTournamentsHistory_fk0] FOREIGN KEY ([TournamentId]) REFERENCES [Tournament]([Id])
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
ALTER TABLE [ResultTournamentPlayer] WITH CHECK ADD CONSTRAINT [ResultTournamentPlayer_fk1] FOREIGN KEY ([TournamentId]) REFERENCES [Tournament]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [ResultTournamentPlayer] CHECK CONSTRAINT [ResultTournamentPlayer_fk1]
GO

ALTER TABLE [ResultTournamentTeam] WITH CHECK ADD CONSTRAINT [ResultTournamentTeam_fk0] FOREIGN KEY ([TeamId]) REFERENCES [Team]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [ResultTournamentTeam] CHECK CONSTRAINT [ResultTournamentTeam_fk0]
GO
ALTER TABLE [ResultTournamentTeam] WITH CHECK ADD CONSTRAINT [ResultTournamentTeam_fk1] FOREIGN KEY ([TournamentId]) REFERENCES [Tournament]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [ResultTournamentTeam] CHECK CONSTRAINT [ResultTournamentTeam_fk1]
GO

ALTER TABLE [Team_Player] WITH CHECK ADD CONSTRAINT [Team_Player_fk0] FOREIGN KEY ([TeamId]) REFERENCES [Team]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Team_Player] CHECK CONSTRAINT [Team_Player_fk0]
GO
ALTER TABLE [Team_Player] WITH CHECK ADD CONSTRAINT [Team_Player_fk1] FOREIGN KEY ([PlayerId]) REFERENCES [Player]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Team_Player] CHECK CONSTRAINT [Team_Player_fk1]
GO

