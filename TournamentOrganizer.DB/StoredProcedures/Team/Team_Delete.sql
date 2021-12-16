Create Proc dbo.Team_Delete
	@Id int
As
Begin
	Delete From Team
	Where Id = @Id 
End 
