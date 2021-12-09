CREATE PROCEDURE [dbo].[TeamTournamentHistory_UpdateTournomentIdByTeamId]
    
 @newTournamentId  int ,@TournamentId int, @TeamId int
AS
BEGIN
   Update [dbo].[TeamTournamentHistory]
   set TournamentId = @newTournamentId
	WHERE TournamentId = @TournamentId and TeamId=@TeamId

END