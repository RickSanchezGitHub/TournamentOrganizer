CREATE PROCEDURE [dbo].[TeamTournamentHistory_DeleteByTournomentId]
    @TournamentId int
AS
BEGIN
     Delete [dbo].[TeamTournamentHistory]
	WHERE TournamentId = @TournamentId
	
END
