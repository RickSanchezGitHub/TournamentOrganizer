create proc dbo.Player_SelectById
	@Id int
as
begin
	select 
		id,
		FirstName,
		LastName,
		NickName
	from  dbo.Player
end
