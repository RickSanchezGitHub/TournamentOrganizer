create proc dbo.Team_Insert
	(@Team_Name varchar(25))
as
begin
	insert into Team
		(TeamName)
	values
		(@Team_Name)
end