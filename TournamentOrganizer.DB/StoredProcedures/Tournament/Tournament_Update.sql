CREATE PROCEDURE [dbo].[Tournament_UpdateById]
	@Id int,
	@Name varchar(50),
	@StartDate date,
	@CloseDate date,
	@GameId int,
	@OnlyForTeams bit
AS
BEGIN
	UPDATE Tournament
	Set	
		Name = @Name,
		StartDate = @StartDate,
		CloseDate = @CloseDate,
		GameId = @GameId,
		OnlyForTeams = @OnlyForTeams
	Where Id = @Id
		
End
