CREATE PROCEDURE [dbo].[TeamTournamentHistory_SelectByTournamentId]
    @TournamentId int
AS
BEGIN
    SELECT TeamId, TournamentId 
    FROM [dbo].[TeamTournamentHistory]
    WHERE  TournamentId = @TournamentId
    END