using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Models;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Mapping
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<AccountDB, Account>()
                .ForMember(opt => opt.FamilyId,
                db => db.MapFrom(inst => inst.FamilyDBId))
                .ForMember(opt => opt.UserId,
                db => db.MapFrom(inst => inst.UserDBId)).ReverseMap();
        }
    }
}
