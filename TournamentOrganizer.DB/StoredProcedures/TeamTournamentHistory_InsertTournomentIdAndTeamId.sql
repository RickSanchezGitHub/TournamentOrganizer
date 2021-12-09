CREATE PROCEDURE [dbo].[TeamTournamentHistory_InsertTournomentIdAndTeamId]
    @TournamentId int, @TeamId int
AS
BEGIN
    Insert INTO [dbo].[TeamTournamentHistory]
	(TeamId, TournamentId )
    values (@TeamId, @TournamentId)

END