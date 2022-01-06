CREATE PROCEDURE [dbo].[Tournament_Insert]
	
	@Name varchar(50),
	@StartDate date,
	@CloseDate date, 
	@GameId int,
	@OnlyForTeams bit
AS
BEGIN
	INSERT Tournament(Name, StartDate, CloseDate, GameId, OnlyForTeams) OUTPUT Inserted.Id Values
	(@Name, @StartDate, @CloseDate, @GameId, @OnlyForTeams)
END
