CREATE TABLE [dbo].[Tournament]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [StartDate] DATE NOT NULL, 
    [CloseDate] DATE NOT NULL, 
    [GameId] INT NOT NULL, 
    CONSTRAINT [FK_Tournament_ToGame] FOREIGN KEY ([GameId]) REFERENCES [Game]([Id])
)
