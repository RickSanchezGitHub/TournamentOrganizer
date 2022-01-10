CREATE PROCEDURE [dbo].[ResultTournamentPlayer_InsertPlayerIdRoundMatchTournament]
	@PlayerId int,
	@NumberRound int,
	@NumberMatch int,
	@TournamentId int

AS
BEGIN
	INSERT INTO [dbo].[ResultTournamentPlayer]
           ([PlayerId]
           ,[NumberRound]
           ,[NumberMatch]
           ,[TournamentId])
     VALUES
           (@PlayerId,
			@NumberRound,
			@NumberMatch,
			@TournamentId)
END
GO