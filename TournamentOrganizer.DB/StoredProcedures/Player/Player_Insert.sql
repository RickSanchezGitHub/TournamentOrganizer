Create Proc dbo.Player_Insert
	 @FirstName varchar(25),
	 @LastName varchar(25),
	 @Name varchar(25),
	 @Email varchar(25),
	 @Birthday date
As
Begin
	Insert Into	Player
		
		 (FirstName,
		 LastName,
		 Name,
		 Email,
		 Birthday)
	Values 
		(@FirstName,
		 @LastName,
		 @Name,
		 @Email,
		 @Birthday)
		 SELECT CAST(SCOPE_IDENTITY() as int)
End
