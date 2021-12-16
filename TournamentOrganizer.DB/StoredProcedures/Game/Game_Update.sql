CREATE PROCEDURE [dbo].[Game_UpdateById]
	@Id int,
	@Name varchar(50)
AS
BEGIN
	UPDATE Game
	Set	
		Name = @Name
	Where Id = @Id		
End
