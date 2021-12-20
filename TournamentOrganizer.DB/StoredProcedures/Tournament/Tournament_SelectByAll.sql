CREATE PROCEDURE [dbo].[Tournament_SelectByAll]
	
AS
Begin 
	SELECT 
	t.Id, 
	t.Name,
	t.StartDate,
	t.CloseDate,
	g.Id,
	g.Name
	From dbo.Tournament t inner join dbo.Game g on t.GameId = g.Id
End

