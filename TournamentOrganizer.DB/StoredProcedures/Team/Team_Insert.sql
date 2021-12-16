create proc dbo.Team_Insert
	@Name varchar(25)
as
begin
	insert into Team
		(Name)
	values
		(@Name)
end