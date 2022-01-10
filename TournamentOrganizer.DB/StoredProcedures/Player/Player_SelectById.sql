Create Proc dbo.Player_SelectById
	@Id int
As
Begin
	Select 
		id,
		FirstName,
		LastName,
		Name,
		Email,
		Birthday
	From  dbo.Player
	Where Id = @Id
End
