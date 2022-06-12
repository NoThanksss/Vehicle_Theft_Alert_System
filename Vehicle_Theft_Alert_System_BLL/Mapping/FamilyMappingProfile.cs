using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Models;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Mapping
{
    public class FamilyMappingProfile : Profile
    {
        public FamilyMappingProfile()
        {
            CreateMap<FamilyDB, Family>()
                .ForMember(opt => opt.FamilyPlanId,
                db => db.MapFrom(inst => inst.FamilyPlanDBId)).ReverseMap();
        }
    }
}
