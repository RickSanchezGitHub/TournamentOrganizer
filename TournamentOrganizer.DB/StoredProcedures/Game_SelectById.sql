CREATE PROCEDURE [dbo].[Game_SelectById]
	@Id int
AS
Begin 
	SELECT 
		Id,
		Name
	From dbo.Game
	Where Id = @Id
End

