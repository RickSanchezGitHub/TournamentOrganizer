CREATE PROCEDURE [dbo].[ResultTournamentPlayer_GetDataOfTournament]
	@TournamentId int
AS
BEGIN
SELECT
	  rtp.Id,
	  rtp.NumberRound,
	  rtp.NumberMatch,
	  rtp.Result,
	  p.Id,
	  p.FirstName,
	  p.LastName,
	  p.Name,
	  p.Birthday,
	  p.Email
  FROM [dbo].[ResultTournamentPlayer] rtp inner join dbo.[Player] p 
  ON rtp.PlayerId = p.Id
  inner join dbo.[Tournament] t 
  ON rtp.TournamentId = t.Id
  WHERE  rtp.TournamentId = @TournamentId
  END