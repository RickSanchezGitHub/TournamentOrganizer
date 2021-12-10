CREATE PROCEDURE [dbo].[Tournament_UpdateById]
	@Id int,
	@Name varchar(50),
	@StartDate date,
	@CloseDate date,
	@GameId int
AS
BEGIN
	UPDATE Tournament
	Set	
		Name = @Name,
		StartDate = @StartDate,
		CloseDate = @CloseDate,
		GameId = @GameId
	Where Id = @Id
		
End
