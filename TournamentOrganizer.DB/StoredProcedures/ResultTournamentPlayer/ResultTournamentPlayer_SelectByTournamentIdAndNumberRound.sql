CREATE PROCEDURE [dbo].[ResultTournamentPlayer_SelectByTournamentIdAndNumberRound]
	@TournamentId int,
	@NumberRound int
AS
BEGIN
	SELECT
	rtp.Id,
	rtp.PlayerId, 
	rtp.Result, 
	rtp.NumberRound, 
	rtp.NumberMatch, 
	rtp.TournamentId,
	p.Id,
	p.FirstName,
	p.LastName,
	p.Name,
	p.Email,
	p.Birthday
	FROM [dbo].[ResultTournamentPlayer] rtp inner join [dbo].Player p ON rtp.PlayerId = p.Id
	WHERE NumberRound = @NumberRound AND TournamentId = @TournamentId
END

/*показывает всё по турниру и раунду (для отображения игроков раунда)*/