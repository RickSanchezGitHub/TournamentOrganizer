using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganaizer.DataLayer.Entities;

namespace TournamentOrganizer.BusinessLayer.Configuration
{
    public static class AutoMapper
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

            }));
        }
    }
}

