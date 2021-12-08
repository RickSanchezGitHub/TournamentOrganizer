create proc dbo.Team_Update
	(@id int,
	 @Team_Name varchar(25))
as
begin
	update 	Team
	set 
		TeamName = @Team_Name
	where 
		 Id = @id
end