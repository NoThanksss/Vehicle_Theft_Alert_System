using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Models;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Mapping
{
    public class ActivityScheduleMappingProfile : Profile
    {
        public ActivityScheduleMappingProfile()
        {
            CreateMap<ActivityScheduleDB, ActivitySchedule>()
                .ForMember(opt => opt.TrackerId,
                db => db.MapFrom(inst => inst.TrackerDBId)).ReverseMap();
        }
    }
}
