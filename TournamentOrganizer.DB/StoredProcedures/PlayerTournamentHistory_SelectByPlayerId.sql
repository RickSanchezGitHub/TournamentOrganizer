CREATE PROCEDURE [dbo].[PlayerTournamentHistory_SelectByPlayerId]
    @PlayerId int
AS
BEGIN
    SELECT PlayerId, TournamentId 
    FROM [dbo].[PlayerTournamentHistory]
    WHERE  PlayerId = @PlayerId
END