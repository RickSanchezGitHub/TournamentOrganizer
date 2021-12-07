CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SelectByTournamentIdAndNumberRound]
	@TournamentId int,
	@NumberRound int
AS
BEGIN
	SELECT PlayerId, Result, NumberRound, NumberGame, TournamentId 
	FROM [dbo].[ResultTournamentPlayer]
	WHERE NumberRound = @NumberRound AND TournamentId = @TournamentId
END