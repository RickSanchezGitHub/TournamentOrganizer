create proc dbo.Team_SelectAll
as
begin
	select
		Id,
		Name
	from  dbo.[Team]
end