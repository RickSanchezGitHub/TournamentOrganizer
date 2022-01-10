CREATE PROCEDURE [dbo].[ResultTournamentPlayer_InsertPlayerAndTournament]
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
