Create Proc dbo.Player_SelectAll
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
End