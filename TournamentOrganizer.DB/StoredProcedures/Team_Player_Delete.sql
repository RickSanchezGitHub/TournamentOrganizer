Create Proc dbo.Team_Player_Delete
	@TeamId int,
	@PlayerId int
As
Begin
	Delete From Team_Player
	Where 
		TeamId = @TeamId And PlayerId = @PlayerId
End