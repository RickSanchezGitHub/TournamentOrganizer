CREATE PROCEDURE [dbo].[ResultTournamentTeam_DeleteByTournamentAndRound]
	@TournamentId int,
	@NumberRound int
AS
BEGIN
	DELETE FROM [dbo].[ResultTournamentTeam]
	WHERE [TournamentId] = @TournamentId AND [NumberRound] = @NumberRound
END
GO