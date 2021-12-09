CREATE PROCEDURE [dbo].[PlayerTournamentHistory_InsertTournomentIdAndPlayerId]
    @TournamentId  int , @PlayerId int
AS
BEGIN
    Insert INTO [dbo].[PlayerTournamentHistory]
  (PlayerId, TournamentId )
    values (@PlayerId, @TournamentId)
END