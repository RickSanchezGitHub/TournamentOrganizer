CREATE PROCEDURE [dbo].[ResultTournamentTeam_SetTeamResultInRoundOfTournament]
	@newResult int,
	@TeamId int,
	@TournamentId int,
	@NumberRound int
AS
BEGIN
	UPDATE [dbo].[ResultTournamentTeam]
	   SET [Result] = @newResult
	WHERE [TeamId] = @TeamId AND [TournamentId] = @TournamentId AND [NumberRound] = @NumberRound
END