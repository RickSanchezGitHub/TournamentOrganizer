using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganaizer.DataLayer.Entities;
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
                cfg.CreateMap<Tournament, TournamentModel>();
                cfg.CreateMap<TournamentModel, Tournament>();
                cfg.CreateMap<Game, GameModel>();
                cfg.CreateMap<GameModel, Game>();
                cfg.CreateMap<Player, PlayerModel>();
                cfg.CreateMap<PlayerModel, Player>();
                cfg.CreateMap<Player, IParticipant>();
                cfg.CreateMap<IParticipant, Player>();
                cfg.CreateMap<IParticipant, PlayerModel>();
                cfg.CreateMap<Team, TeamModel>();
                cfg.CreateMap<TeamModel, Team>();



                cfg.CreateMap<TeamPlayer, TeamPlayerModel>();
                cfg.CreateMap<TeamPlayerModel, TeamPlayer>();
            }));

        }
    }
}