Create Proc dbo.Team_Player_Insert
	@TeamId int,
	@PlayerId int
As
Begin
	Insert Into Team_Player
		(TeamId,
		PlayerId)
	Values
		(@TeamId,
		@PlayerId)
End