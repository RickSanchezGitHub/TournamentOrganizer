CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SelectTeamsInTournament]
	@TournamentId int
AS
BEGIN
SELECT
	  p.Id,
	  p.Name
  FROM [dbo].[ResultTournamentTeam] rtp inner join dbo.[Team] p 
  ON rtp.Id = p.Id
  WHERE  rtp.TournamentId = @TournamentId
  END