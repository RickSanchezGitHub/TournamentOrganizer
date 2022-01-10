CREATE PROCEDURE [dbo].[ResultTournamentPlayer_DeleteByPlayerIdAndTournamentId]
	@PlayerId int,
	@TournamentId int
AS
BEGIN
	DELETE FROM [dbo].[ResultTournamentPlayer]
	WHERE [TournamentId] = @TournamentId AND [PlayerId] = @PlayerId
END