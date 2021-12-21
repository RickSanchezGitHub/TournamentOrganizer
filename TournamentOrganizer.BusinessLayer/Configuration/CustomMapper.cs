using AutoMapper;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.DataLayer.Entities;

namespace TournamentOrganizer.BusinessLayer.Configuration
{
    public static class CustomMapper
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitCustomMapper();
            }
            return _instance;
        }
        public static void InitCustomMapper()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Team, TeamModel>();
                cfg.CreateMap<TeamModel, Team>();
                cfg.CreateMap<Player, PlayerModel>();
                cfg.CreateMap<PlayerModel, Player>();

            }));
        }
    }
}
