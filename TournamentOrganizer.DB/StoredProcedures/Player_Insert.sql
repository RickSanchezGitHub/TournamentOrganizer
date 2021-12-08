create proc dbo.Player_Insert
	(@First_Name varchar,
	 @Last_Name varchar,
	 @Nick_Name varchar)
as
begin
	insert into	Player
		(
		 FirstName,
		 LastName,
		 NickName)
	values 
		(@First_Name,
		 @Last_Name,
		 @Nick_Name)
end
