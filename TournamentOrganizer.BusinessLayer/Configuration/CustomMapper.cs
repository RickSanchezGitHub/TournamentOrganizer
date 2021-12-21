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
                cfg.CreateMap<ResultTournamentPlayer, ResultTournamentPlayerModel>();
            }));
        }
    }
}

