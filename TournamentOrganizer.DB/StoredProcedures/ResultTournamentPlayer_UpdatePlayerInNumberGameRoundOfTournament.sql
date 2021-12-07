CREATE PROCEDURE [dbo].[ResultTournamentPlayer_UpdatePlayerInNumberGameRoundOfTournament]
	@newPlayerId int,
	@PlayerId int,
	@NumberGame int,
	@NumberRound int,
	@TournamentId int
AS
BEGIN
	UPDATE [dbo].[ResultTournamentPlayer]
	   SET [PlayerId] = @PlayerId
	WHERE [PlayerId] = @PlayerId AND [TournamentId] = @TournamentId AND [NumberRound] = @NumberRound AND [NumberGame] = @NumberGame
END

/*тут наверное для того, чтобы поменять игроков местами, если что, но вообще в этих строках уже будет результат, 
тогда и его менять с помощью ResultTournamentPlayer_SetPlayerResultInRoundOfTournament
по хорошему нужно добавить проверку, есть ли newPlayerId в раунде турнира*/