create proc [dbo].[Team_Player_SelectByPlayerId]
	@PlayerId int
as
begin
	select 
		tp.*,		
		t.*
	from  dbo.[Team_Player] tp 
	inner join dbo.[Team] t on tp.TeamId = t.Id 
	where tp.PlayerId = @PlayerId
end
