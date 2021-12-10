Create Proc dbo.Player_Insert
	 @FirstName varchar(25),
	 @LastName varchar(25),
	 @NickName varchar(25),
	 @Email varchar(25),
	 @Birthday date
As
Begin
	Insert Into	Player
		
		 (FirstName,
		 LastName,
		 NickName,
		 Email,
		 Birthday)
	Values 
		(@FirstName,
		 @LastName,
		 @NickName,
		 @Email,
		 @Birthday)
End
