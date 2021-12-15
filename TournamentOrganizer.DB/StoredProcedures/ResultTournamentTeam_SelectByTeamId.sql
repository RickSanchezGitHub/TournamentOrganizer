CREATE PROCEDURE [dbo].[ResultTournamentTeam_SelectByTeamId] 
    @TeamId int 
AS 
BEGIN 
   select 
  rtt.Id, 
  rtt.TeamId, 
  rtt.Result, 
  rtt.NumberRound, 
  rtt.NumberMatch, 
  rtt.TournamentId, 
  t.Id, 
  t.Name, 
  t.StartDate, 
  t.StartDate, 
  t.CloseDate, 
  t.GameId 
 from dbo.[ResultTournamentTeam] rtt inner join dbo.Tournament t on rtt.TournamentId =t.Id 
    WHERE  TeamId = @TeamId 
END