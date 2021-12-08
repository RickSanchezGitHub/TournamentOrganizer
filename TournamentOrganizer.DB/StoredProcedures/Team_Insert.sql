create proc dbo.Team_Insert
	(@Team_Name varchar)
as
begin
	insert into Team
		(TeamName)
	values
		(@Team_Name)
end