CREATE PROCEDURE [dbo].[ResultTournamentTeam_SelectByTeamIdAndTournamentId]
    @TeamId int, @TournamentId int
AS
BEGIN
   select
te.* , r.*
from dbo.[ResultTournamentTeam] r inner join dbo.Team te on r.TeamId =te.Id 
    WHERE  TeamId = @TeamId and TournamentId=@TournamentId
END