Create Proc dbo.Player_UpdateNickName
	(@id int,
	 @Nick_Name varchar)
as
begin
	update	Player
	set
		 NickName = @Nick_Name
	where Id = @id
end
