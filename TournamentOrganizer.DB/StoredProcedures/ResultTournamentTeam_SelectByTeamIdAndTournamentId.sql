CREATE PROCEDURE [dbo].[ResultTournamentTeam_SelectByTeamIdAndTournamentId]
    @TeamId int,
    @TournamentId int
AS
BEGIN
   SELECT
        t.Id ,
        t.Name,
        rtt.Id,
        rtt.NumberMatch,
        rtt.NumberRound,
        rtt.Result,
        rtt.TeamId,
        rtt.TournamentId
    FROM  dbo.[ResultTournamentTeam] rtt inner join dbo.Team t ON rtt.TeamId =t.Id 
    WHERE  TeamId = @TeamId and TournamentId=@TournamentId
END