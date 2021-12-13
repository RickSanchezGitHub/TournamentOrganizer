CREATE PROCEDURE [dbo].[ResultTournamentTeam_SelectByTeamId]
    @TeamId int
AS
BEGIN
   select
rtt.* , t.*
from dbo.[ResultTournamentTeam] rtt inner join dbo.Team t on rtt.TeamId =t.Id
    WHERE  TeamId = @TeamId
END