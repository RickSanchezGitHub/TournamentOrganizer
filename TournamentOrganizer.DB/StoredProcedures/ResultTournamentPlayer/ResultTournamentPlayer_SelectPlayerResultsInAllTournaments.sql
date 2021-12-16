CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SelectPlayerResultsInAllTournaments]
	@PlayerId int
AS
BEGIN
SELECT
	  rtp.Id,
	  rtp.[Result],
      rtp.[NumberRound],
      rtp.[NumberMatch],
	  rtp.TournamentId,
	  p.Id,
	  p.FirstName,
	  p.LastName,
	  p.NickName,
	  p.Birthday
  FROM [dbo].[ResultTournamentPlayer] rtp inner join dbo.[Player] p 
  ON rtp.PlayerId = p.Id
  WHERE  rtp.PlayerId = @PlayerId
  END
