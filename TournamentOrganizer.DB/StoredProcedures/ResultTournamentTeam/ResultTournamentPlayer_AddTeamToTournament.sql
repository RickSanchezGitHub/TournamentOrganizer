CREATE PROCEDURE [dbo].[ResultTournamentPlayer_AddTeamToTournament]
	@TeamId int,
	@TournamentId int

AS
BEGIN
	INSERT INTO [dbo].[ResultTournamentTeam]
           ([TeamId]
           ,[TournamentId])
     VALUES
           (@TeamId,
			@TournamentId)
END
