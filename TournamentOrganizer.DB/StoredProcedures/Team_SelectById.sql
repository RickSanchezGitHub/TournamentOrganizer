Create proc [dbo].[Team_SelectById]
	@Id int
as
begin
	select 
		t.*,
		tp.TeamId,
		tp.PlayerId,
		p.*
	from  dbo.[Team] t 
	inner join dbo.[Team_Player] tp on tp.TeamId = t.Id 
	inner join dbo.[Player] p on p.Id = tp.PlayerId
	where t.Id = @Id
end
