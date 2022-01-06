CREATE PROCEDURE [dbo].[Tournament_SelectById]
	@Id int
AS
Begin 
	SELECT 
    t.Id, 
	t.Name,
	t.StartDate,
	t.CloseDate,
	t.OnlyForTeams,
	g.Id,
	g.Name
	From dbo.Tournament t inner join dbo.Game g on t.GameId = g.Id
	Where t.Id = @Id
End

