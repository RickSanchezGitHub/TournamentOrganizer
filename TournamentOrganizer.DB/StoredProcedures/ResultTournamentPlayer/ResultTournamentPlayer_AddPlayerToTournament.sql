CREATE PROCEDURE [dbo].[ResultTournamentPlayer_AddPlayerToTournament]
	@PlayerId int,
	@TournamentId int

AS
BEGIN
	INSERT INTO [dbo].[ResultTournamentPlayer]
           ([PlayerId]
           ,[TournamentId])
     VALUES
           (@PlayerId,
			@TournamentId)
END
