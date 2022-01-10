CREATE PROCEDURE [dbo].[ResultTournamentTeam_InsertTeamIdRoundMatchTournament]
	@TeamId int,
	@NumberRound int,
	@NumberMatch int,
	@TournamentId int

AS
BEGIN
	INSERT INTO [dbo].[ResultTournamentTeam]
           ([TeamId]
           ,[NumberRound]
           ,[NumberMatch]
           ,[TournamentId])
     VALUES
           (@TeamId,
			@NumberRound,
			@NumberMatch,
			@TournamentId)
END