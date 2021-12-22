﻿create proc dbo.Team_SelectAll
as
begin
	select
		t.Id,
		t.Name,
		p.Id,
		p.FirstName,
		p.LastName,
		p.NickName,
		p.NickName,
		p.Email,
		p.Birthday
	from  dbo.[Team] t 
	inner join dbo.[Team_Player] tp on tp.TeamId = t.Id 
	inner join dbo.[Player] p on p.Id = tp.PlayerId
end