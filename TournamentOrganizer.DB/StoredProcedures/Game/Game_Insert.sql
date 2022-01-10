CREATE PROCEDURE [dbo].[Game_Insert]
	@Name varchar(50),
	@Description varchar(301)

AS
BEGIN
	INSERT INTO Game( Name, Description) Values
	(@Name, @Description)
	SELECT CAST(SCOPE_IDENTITY() as int)
END
