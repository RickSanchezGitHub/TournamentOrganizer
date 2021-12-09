CREATE PROCEDURE [dbo].[PlayerTournamentHistory_SelectByTournamentId]
    @TournamentId int
AS
BEGIN
    SELECT PlayerId, TournamentId 
    FROM [dbo].[PlayerTournamentHistory]
    WHERE  TournamentId = @TournamentId
END