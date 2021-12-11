CREATE PROCEDURE [dbo].[Tournament_DeleteById]
	@Id int
	
AS
Begin
	Delete dbo.Tournament Where Id = @Id
End

