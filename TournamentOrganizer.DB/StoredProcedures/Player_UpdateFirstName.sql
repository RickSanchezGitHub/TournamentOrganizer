Create proc dbo.Player_UpdateFirstName
	(@id int,
	 @First_Name varchar(25))
as
begin
	update	Player
	set
		FirstName = @First_Name
	where Id = @id
end