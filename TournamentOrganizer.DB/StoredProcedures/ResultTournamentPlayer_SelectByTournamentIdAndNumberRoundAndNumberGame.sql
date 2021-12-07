CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SelectByTournamentIdAndNumberRoundAndNumberGame]
	@TournamentId int,
	@NumberRound int,
	@NumberGame int
AS
BEGIN
	SELECT PlayerId, Result, NumberRound, NumberGame, TournamentId 
	FROM [dbo].[ResultTournamentPlayer]
	WHERE NumberRound = @NumberRound AND TournamentId = @TournamentId AND NumberGame = @NumberGame
END

/*показывает строки таблицы по турниру, раунду и партии (может помочь для извлечения соперников в конкретном раунде)*/