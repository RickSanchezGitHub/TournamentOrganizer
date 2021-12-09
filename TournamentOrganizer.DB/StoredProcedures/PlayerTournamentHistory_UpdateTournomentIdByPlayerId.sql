CREATE PROCEDURE [dbo].[PlayerTournamentHistory_UpdateTournomentIdByPlayerId]
    @newTournamentId  int ,@TournamentId int, @PlayerId int
AS
BEGIN
   Update [dbo].[PlayerTournamentHistory]
   set TournamentId = @newTournamentId
	WHERE TournamentId = @TournamentId and PlayerId=@PlayerId

END
