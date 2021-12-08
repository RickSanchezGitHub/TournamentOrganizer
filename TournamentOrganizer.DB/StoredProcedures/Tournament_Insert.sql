CREATE PROCEDURE [dbo].[Tournament_Insert]
	@Id int,
	@Name varchar(50),
	@StartDate date,
	@CloseDate date, 
	@GameId int
AS
BEGIN
	INSERT Tournament(Id, Name, StartDate, CloseDate, GameId) Values
	(@Id, @Name, @StartDate, @CloseDate, @GameId)
END
