CREATE PROCEDURE [dbo].[ResultTournamentTeam_SelectByTeamId]
    @TeamId int
AS
BEGIN
   select
te.* , r.*
from dbo.[ResultTournamentTeam] r inner join dbo.Team te on r.TeamId =te.Id
    WHERE  TeamId = @TeamId
END