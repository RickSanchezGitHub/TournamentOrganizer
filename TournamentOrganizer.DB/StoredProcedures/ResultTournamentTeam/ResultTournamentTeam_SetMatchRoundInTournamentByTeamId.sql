CREATE PROCEDURE [dbo].[ResultTournamentTeam_SetMatchRoundInTournamentByTeamId]
	@TournamentId int,
	@TeamId int,
	@NumberMatch int,
	@NumberRound int
AS
BEGIN
	UPDATE [dbo].[ResultTournamentTeam]
	   SET [NumberRound] = @NumberRound, [NumberMatch] = @NumberMatch
	WHERE [TeamId] = @TeamId AND [TournamentId] = @TournamentId
END