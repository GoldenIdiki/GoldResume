using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldResumePage.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<UpdateCarDto, Car>().ReverseMap();
            //.ForMember(c => c.CategoryPositions, option => option.Ignore())
            //.ForMember(c => c.Posts, option => option.Ignore());
        }
    }
}
