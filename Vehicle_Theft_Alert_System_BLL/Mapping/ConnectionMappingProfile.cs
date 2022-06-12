using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Models;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Mapping
{
    internal class ConnectionMappingProfile : Profile
    {
        public ConnectionMappingProfile()
        {
            CreateMap<ConnectionDB, Connection>()
                .ForMember(opt => opt.TrackerId,
                db => db.MapFrom(inst => inst.TrackerDBId))
                .ForMember(opt => opt.FamilyId,
                db => db.MapFrom(inst => inst.FamilyDBId))
                .ForMember(opt => opt.AccountId,
                db => db.MapFrom(inst => inst.AccountDBId)).ReverseMap();
        }
    }
}
