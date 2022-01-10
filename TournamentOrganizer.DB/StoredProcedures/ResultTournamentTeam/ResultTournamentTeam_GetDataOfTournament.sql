CREATE PROCEDURE [dbo].[ResultTournamentTeam_GetDataOfTournament]
	@TournamentId int
AS
BEGIN
SELECT
	  rtt.Id,
	  rtt.NumberRound,
	  rtt.NumberMatch,
	  rtt.Result,
	  rtt.TournamentId,
	  t.Id,
	  t.Name
  FROM [dbo].[ResultTournamentTeam] rtt inner join dbo.[Team] t 
  ON rtt.TeamId = t.Id
  inner join dbo.[Tournament] tour 
  ON rtt.TournamentId = tour.Id
  WHERE  rtt.TournamentId = @TournamentId
  END