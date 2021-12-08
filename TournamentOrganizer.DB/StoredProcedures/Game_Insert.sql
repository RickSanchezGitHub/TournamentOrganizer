CREATE PROCEDURE [dbo].[Game_Insert]
	@Name varchar(50)

AS
BEGIN
	INSERT Game( Name) Values
	(@Name)
END
