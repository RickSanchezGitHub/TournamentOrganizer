CREATE PROCEDURE [dbo].[ResultTournamentTeam_SelectByTournamentId] 
    @TournamentId int 
AS 
BEGIN 
   SELECT 
        t.Id, 
        t.Name, 
        rtt.Id, 
        rtt.Result, 
        rtt.TeamId, 
        rtt.NumberRound, 
        rtt.NumberMatch, 
        rtt.TournamentId 
    FROM dbo.[ResultTournamentTeam] rtt inner join dbo.Team t ON rtt.TeamId =t.Id 
    WHERE  TournamentId = @TournamentId 
END