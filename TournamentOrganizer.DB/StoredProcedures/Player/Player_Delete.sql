Create Proc dbo.Player_Delete
	@Id int
As
Begin
	Delete From Player
	Where Id = @Id
End