Create proc dbo.Player_UpdateLasttName
	(@id int,
	 @Last_Name varchar(25))
as
begin
	update	Player
	set
		LastName = @Last_Name
	where Id = @id
end