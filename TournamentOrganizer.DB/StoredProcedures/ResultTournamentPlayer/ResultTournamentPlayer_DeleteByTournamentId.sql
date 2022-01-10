CREATE PROCEDURE ResultTournamentPlayer_DeleteByTournamentId
	@TournamentId int,
	@PlayerId int
AS
BEGIN
	DELETE [dbo].[ResultTournamentPlayer]
	WHERE TournamentId = @TournamentId AND
	      PlayerId = @PlayerId

END
GO
