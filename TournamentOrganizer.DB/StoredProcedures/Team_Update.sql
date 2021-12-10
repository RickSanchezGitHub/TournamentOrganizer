create proc dbo.Team_Update
	 @Id int,
	 @Name varchar(25)
as
begin
	update 	Team
	set 
		Name = @Name
	where 
		 Id = @Id
end