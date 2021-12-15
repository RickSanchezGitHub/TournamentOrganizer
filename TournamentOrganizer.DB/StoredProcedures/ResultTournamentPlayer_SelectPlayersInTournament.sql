CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SelectPlayersInTournament]
	@TournamentId int
AS
BEGIN
SELECT
	  p.Id,
	  p.FirstName,
	  p.LastName,
	  p.NickName,
	  p.Birthday,
	  p.Email,
	  rtp.Id
  FROM [dbo].[ResultTournamentPlayer] rtp inner join dbo.[Player] p 
  ON rtp.PlayerId = p.Id
  WHERE  rtp.TournamentId = @TournamentId
  END