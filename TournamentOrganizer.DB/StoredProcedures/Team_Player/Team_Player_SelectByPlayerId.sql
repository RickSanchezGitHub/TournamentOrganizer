CREATE PROC [dbo].[Team_Player_SelectByPlayerId]
	@PlayerId int
AS
BEGIN
	SELECT 
		tp.*,		
		t.*
	FROM  dbo.[Team_Player] tp 
	inner join dbo.[Team] t ON tp.TeamId = t.Id 
	WHERE tp.PlayerId = @PlayerId
END
