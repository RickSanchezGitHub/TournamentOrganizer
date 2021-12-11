Create Proc dbo.Player_SelectAll
As
Begin
	Select 
		id,
		FirstName,
		LastName,
		NickName,
		Email,
		Birthday
	From  dbo.Player
End