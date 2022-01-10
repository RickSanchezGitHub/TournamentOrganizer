Create Proc dbo.Player_Update
	 @Id int,
	 @FirstName varchar(25),
	 @LastName varchar(25),
	 @Name varchar(25),
	 @Birthday date
As
Begin
	Update	Player
	Set
		FirstName = @FirstName,
		LastName = @LastName,
		Name = @Name,
		Birthday = @Birthday
	Where Id = @id
End