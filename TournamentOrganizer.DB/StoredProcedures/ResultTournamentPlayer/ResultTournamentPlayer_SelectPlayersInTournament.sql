CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SelectPlayersInTournament]
	@TournamentId int
AS
BEGIN
SELECT
	  
	  p.FirstName,
	  p.LastName,
	  p.Name,
	  p.Birthday,
	  p.Email,
	  rtp.Id,
	  p.Id
  FROM [dbo].[ResultTournamentPlayer] rtp inner join dbo.[Player] p 
  ON rtp.PlayerId = p.Id
  WHERE  rtp.TournamentId = @TournamentId
  END