Create proc [dbo].[Team_Player_SelectByTeamId]
	@Id int
as
begin
	select 
		t.*,		
		p.*
	from  dbo.[Team] t 
	inner join dbo.[Team_Player] tp on tp.TeamId = t.Id 
	inner join dbo.[Player] p on p.Id = tp.PlayerId
	where t.Id = @Id
end
