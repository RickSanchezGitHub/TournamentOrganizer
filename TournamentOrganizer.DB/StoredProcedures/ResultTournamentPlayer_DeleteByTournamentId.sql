CREATE PROCEDURE ResultTournamentPlayer_DeleteByTournamentId
	@TournamentId int
AS
BEGIN
	DELETE [dbo].[ResultTournamentPlayer]
	WHERE TournamentId = @TournamentId
END
GO
