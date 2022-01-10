CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SetPlayerResultMatchRoundInTournament]
	@TournamentId int,
	@PlayerId int,
	@newResult int,
	@NumberMatch int,
	@NumberRound int
AS
BEGIN
	UPDATE [dbo].[ResultTournamentPlayer]
	   SET [Result] = @newResult, [NumberRound] = @NumberRound, [NumberMatch] = @NumberMatch
	WHERE [PlayerId] = @PlayerId AND [TournamentId] = @TournamentId
END