create proc dbo.Team_Delete
	@id int
as
begin
	delete from Team
	where Id = @id
end 
