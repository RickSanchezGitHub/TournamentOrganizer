create proc dbo.Player_Insert
	(@First_Name varchar(25),
	 @Last_Name varchar(25),
	 @Nick_Name varchar(25))
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
