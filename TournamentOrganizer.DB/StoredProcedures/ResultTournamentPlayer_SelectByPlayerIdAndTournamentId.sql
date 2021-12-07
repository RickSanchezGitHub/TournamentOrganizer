CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SelectByPlayerIdAndTournamentId]
	@PlayerId int,
	@TournamentId int
AS
BEGIN
	SELECT PlayerId, Result, NumberRound, NumberGame, TournamentId 
	FROM [dbo].[ResultTournamentPlayer]
	WHERE PlayerId = @PlayerId AND TournamentId = @TournamentId
END
