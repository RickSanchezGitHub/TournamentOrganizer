CREATE PROCEDURE dbo.ResultTournamentTeam_DeleteByTournamentId

    @TournamentId int,
    @TeamId int
AS
BEGIN
   	DELETE [dbo].[ResultTournamentTeam]
	WHERE TournamentId = @TournamentId AND
	      TeamId = @TeamId
END
GO