CREATE PROCEDURE [dbo].[Game_DeleteById]
	@Id int
AS
Begin
	Delete dbo.Game Where Id = @Id
End

