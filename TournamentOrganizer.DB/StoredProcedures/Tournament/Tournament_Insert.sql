CREATE PROCEDURE [dbo].[Tournament_Insert]
	
	@Name varchar(50),
	@StartDate date,
	@CloseDate date, 
	@GameId int
AS
BEGIN
	INSERT Tournament(Name, StartDate, CloseDate, GameId) Values
	(@Name, @StartDate, @CloseDate, @GameId)
END
