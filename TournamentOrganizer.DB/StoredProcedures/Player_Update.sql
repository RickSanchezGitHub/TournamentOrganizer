Create Proc dbo.Player_UpdateFirstName
	 @Id int,
	 @FirstName varchar(25),
	 @LastName varchar(25),
	 @NickName varchar(25)
As
Begin
	Update	Player
	Set
		FirstName = @FirstName,
		LastName = @LastName,
		NickName = @NickName
	Where Id = @id
End