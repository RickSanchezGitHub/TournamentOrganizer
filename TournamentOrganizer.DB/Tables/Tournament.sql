CREATE TABLE [dbo].[Tournament]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [StartDate] SMALLDATETIME NOT NULL, 
    [CloseDate] SMALLDATETIME NOT NULL, 
    [GameId] INT NOT NULL, 
    [OnlyForTeams] BIT NOT NULL , 
    CONSTRAINT [FK_Tournament_ToGame] FOREIGN KEY ([GameId]) REFERENCES [Game]([Id])
)
