CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SetMatchRoundByPlayerAndTournament]
	@TournamentId int,
	@PlayerId int,
	@NumberMatch int,
	@NumberRound int
AS
BEGIN
	UPDATE [dbo].[ResultTournamentPlayer]
	   SET [NumberRound] = @NumberRound, [NumberMatch] = @NumberMatch
	WHERE [PlayerId] = @PlayerId AND [TournamentId] = @TournamentId
END
GO