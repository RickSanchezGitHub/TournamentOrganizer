CREATE PROCEDURE [dbo].[Tournament_SelectById]
	@Id int
AS
Begin 
	SELECT 
		Id,
		Name,
		StartDate,
		CloseDate,
		GameId
	From dbo.Tournament
	Where Id = @Id
End

