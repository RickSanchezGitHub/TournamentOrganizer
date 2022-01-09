CREATE PROCEDURE [dbo].[Team_GetAvailablePlayersToAdd]
	@TeamId int
AS
BEGIN

Select* from Player
EXCEPT
Select p.* from  dbo.[Team] t 
left join dbo.[Team_Player] tp on tp.TeamId = t.Id 
left join dbo.[Player] p on p.Id = tp.PlayerId
where t.Id = @TeamId

END
