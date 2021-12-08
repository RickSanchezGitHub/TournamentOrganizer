CREATE PROCEDURE [dbo].[Game_Insert]
	@Id int,
	@Name varchar(50)

AS
BEGIN
	INSERT Game(Id, Name) Values
	(@Id, @Name)
END
