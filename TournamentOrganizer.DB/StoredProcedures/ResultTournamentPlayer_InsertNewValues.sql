CREATE PROCEDURE [dbo].[ResultTournamentPlayer_InsertNewValues]
	@PlayerId int,
	@Result int,
	@NumberRound int,
	@NumberGame int,
	@TournamentId int

AS
BEGIN
	INSERT INTO [dbo].[ResultTournamentPlayer]
           ([PlayerId]
           ,[Result]
           ,[NumberRound]
           ,[NumberGame]
           ,[TournamentId])
     VALUES
           (@PlayerId,
			@Result,
			@NumberRound,
			@NumberGame,
			@TournamentId)
END
