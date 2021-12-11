Create Proc dbo.Player_Update
	 @Id int,
	 @FirstName varchar(25),
	 @LastName varchar(25),
	 @NickName varchar(25),
	 @Email varchar(50),
	 @Birthday date
As
Begin
	Update	Player
	Set
		FirstName = @FirstName,
		LastName = @LastName,
		NickName = @NickName,
		Email = @Email,
		Birthday = @Birthday
	Where Id = @id
End