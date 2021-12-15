CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SetPlayerResultInRoundOfTournament]
	@newResult int,
	@PlayerId int,
	@TournamentId int,
	@NumberRound int
AS
BEGIN
	UPDATE [dbo].[ResultTournamentPlayer]
	   SET [Result] = @newResult
	WHERE [PlayerId] = @PlayerId AND [TournamentId] = @TournamentId AND [NumberRound] = @NumberRound
END

/*обновление результата выбранного игрока в выбранном раунде, выбранного турнира*/