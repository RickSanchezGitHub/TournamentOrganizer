CREATE PROCEDURE [dbo].[TeamTournamentHistory_SelectByTeamId]
    @TeamId int
AS
BEGIN
    SELECT TeamId, TournamentId 
    FROM [dbo].[TeamTournamentHistory]
    WHERE  TeamId = @TeamId
END