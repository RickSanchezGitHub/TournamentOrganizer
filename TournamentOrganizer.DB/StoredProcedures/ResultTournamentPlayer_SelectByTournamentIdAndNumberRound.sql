CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SelectByTournamentIdAndNumberRound]
	@TournamentId int,
	@NumberRound int
AS
BEGIN
	SELECT PlayerId, Result, NumberRound, NumberMatch, TournamentId 
	FROM [dbo].[ResultTournamentPlayer]
	WHERE NumberRound = @NumberRound AND TournamentId = @TournamentId
END

/*показывает всё по турниру и раунду (для отображения игроков раунда)*/