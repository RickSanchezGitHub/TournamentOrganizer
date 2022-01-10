CREATE PROCEDURE [dbo].[ResultTournamentPlayer_DeleteByTournamentAndRound]
	@TournamentId int,
	@NumberRound int
AS
BEGIN
	DELETE FROM [dbo].[ResultTournamentPlayer]
	WHERE [TournamentId] = @TournamentId AND [NumberRound] = @NumberRound
END