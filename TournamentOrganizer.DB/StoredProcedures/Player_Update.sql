create proc dbo.Player_UpDate
	(@id int,
	 @First_Name varchar,
	 @Last_Name varchar,
	 @Nick_Name varchar)
as
begin
	update	Player
	set
		 FirstName =@First_Name,
		 LastName = @Last_Name,
		 NickName = @Nick_Name
	where Id = @id
end
