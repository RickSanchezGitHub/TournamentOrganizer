Create Proc dbo.Player_UpdateNickName
	(@id int,
	 @Nick_Name varchar(25))
as
begin
	update	Player
	set
		 NickName = @Nick_Name
	where Id = @id
end
