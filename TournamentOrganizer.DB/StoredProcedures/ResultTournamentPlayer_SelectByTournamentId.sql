CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SelectByTournamentId]
	@TournamentId int
AS
BEGIN
	SELECT PlayerId, Result, NumberRound, NumberGame, TournamentId 
	FROM [dbo].[ResultTournamentPlayer]
	WHERE TournamentId = @TournamentId
END

/*показывает строки таблицы по турниру, раунду и партии (может помочь для извлечения соперников в конкретном раунде)*/