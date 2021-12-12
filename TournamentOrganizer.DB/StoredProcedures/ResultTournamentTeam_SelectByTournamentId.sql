CREATE PROCEDURE [dbo].[ResultTournamentTeam_SelectByTournamentId]
    @TournamentId int
AS
BEGIN
   select
t.* , r.*
from dbo.[ResultTournamentTeam] r inner join dbo.Tournament t on r.TournamentId =t.Id
    WHERE  TournamentId = @TournamentId
END
