CREATE PROCEDURE dbo.ResultTournamentTeam_DeleteByTournamentId

    @TournamentId int
AS
BEGIN
    DELETE[dbo].[ResultTournamentTeam]
        WHERE TournamentId = @TournamentId
END
GO