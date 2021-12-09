CREATE PROCEDURE [dbo].[PlayerTournamentHistory_DeleteByTournomentId]
    @TournamentId  int 
AS
BEGIN
    Delete [dbo].[PlayerTournamentHistory]
  WHERE TournamentId = @TournamentId

END