CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SelectByPlayerIdAndTournamentId]
	@PlayerId int,
	@TournamentId int
AS
BEGIN
	SELECT PlayerId, Result, NumberRound, NumberMatch, TournamentId 
	FROM [dbo].[ResultTournamentPlayer]
	WHERE PlayerId = @PlayerId AND TournamentId = @TournamentId
END
/*показывает данные по игроку в конкретном турнире (можно посмотреть результаты всех его раундов и потом уже 
считать сумму очков)*/