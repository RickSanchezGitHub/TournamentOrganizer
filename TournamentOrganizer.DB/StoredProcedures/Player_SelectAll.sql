create proc dbo.Player_SelectAll
as
begin
	select 
		id,
		FirstName,
		LastName,
		NickName
	from  dbo.Player
end