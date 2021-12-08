create proc dbo.Team_Player_Insert
	@Team_Id int,
	@Player_Id int
as
begin
	insert into Team_Player
		(TeamId,
		PlayerId)
	values
		(@Team_Id,
		@Player_Id)
end