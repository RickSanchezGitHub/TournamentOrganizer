create proc dbo.Team_Player_Delete
	@Team_Id int
as
begin
	delete from Team_Player
	where 
		TeamId = @Team_Id
end