CREATE PROCEDURE [dbo].[ResultTournamentTeam_SelectByTournamentIdAndNumberRound]
	@TournamentId int,
	@NumberRound int
AS
BEGIN
	SELECT
	rtt.Id, 
	rtt.Result, 
	rtt.NumberRound, 
	rtt.NumberMatch, 
	t.Id,
	t.Name
	FROM [dbo].[ResultTournamentTeam] rtt inner join [dbo].Team t ON rtt.TeamId = t.Id
	WHERE NumberRound = @NumberRound AND TournamentId = @TournamentId
END