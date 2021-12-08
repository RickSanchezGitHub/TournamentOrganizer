create proc dbo.Player_UpDate
	(@id int,
	 @First_Name varchar(25),
	 @Last_Name varchar(25),
	 @Nick_Name varchar(25))
as
begin
	update	Player
	set
		 FirstName =@First_Name,
		 LastName = @Last_Name,
		 NickName = @Nick_Name
	where Id = @id
end
