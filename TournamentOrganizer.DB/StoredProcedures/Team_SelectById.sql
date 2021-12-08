create proc dbo.Team_SelectById
	(@id int)
as
begin
	select 
		id,
		TeamName
	from  dbo.Team
	where Id = @id
end
