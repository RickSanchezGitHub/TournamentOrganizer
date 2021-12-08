create proc dbo.Player_Delete
	(@id int)
as
begin
	delete from Player
	where Id = @id
end