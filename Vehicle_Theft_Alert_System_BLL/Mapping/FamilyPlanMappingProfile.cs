using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Models;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Mapping
{
    public class FamilyPlanMappingProfile : Profile
    {
        public FamilyPlanMappingProfile()
        {
            CreateMap<FamilyPlanDB, FamilyPlan>().ReverseMap();
        }
    }
}
