 CREATE PROCEDURE[dbo].[ResultTournamentTeam_Insert]
    @TeamId int,
	@Result int,
	@NumberRound int,
	@NumberMatch int,
	@TournamentId int

AS
BEGIN
    INSERT INTO[dbo].[ResultTournamentTeam]
          ([TeamId]
          ,[Result]
          ,[NumberRound]
          ,[NumberMatch]
          ,[TournamentId])
    VALUES
          (@TeamId,
           @Result,
           @NumberRound,
           @NumberMatch,
           @TournamentId)
END