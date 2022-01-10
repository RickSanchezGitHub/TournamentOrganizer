CREATE PROCEDURE [dbo].[ResultTournamentTeam_DeleteByTeamIdAndTournamentId]
	@TeamId int,
	@TournamentId int
AS
BEGIN
	DELETE FROM [dbo].[ResultTournamentTeam]
	WHERE [TournamentId] = @TournamentId AND [TeamId] = @TeamId
END
GO