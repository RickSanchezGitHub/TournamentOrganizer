create proc dbo.Team_SelectById
	@Id int
as
begin
	select 
		Id,
		Name
	from  dbo.Team
	where Id = @Id
end
