﻿using WebAPICalendar.DataContract;
using WebSiteOrgStructure.Data.Models;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Profile;
public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<OrganizationalStructureDto, Department>();
        CreateMap<OrganizationalStructureDto, User>();
        CreateMap<DepartmentStruct, DepartmentStructDto>();
        CreateMap<UserCreateDto, User>()
            .ForMember(dest => dest.Id,
            opt => opt.MapFrom(src => Guid.NewGuid())); ;
        CreateMap<User, UserReadDto>();
        CreateMap<Department, DepartmentReadDto>();
        CreateMap<DepartmentCreateDto, Department>()
           .ForMember(dest => dest.Id,
           opt => opt.MapFrom(src => Guid.NewGuid()))
           .ForMember(dest => dest.ParentDepartmentName,
          opt => opt.MapFrom(src => src.CheckParent == "Yes" ? null : src.ParentDepartmentName));
        CreateMap<UserUpdateDto, User>();
        CreateMap<Calendar, Str_Calendar>()
            .ForMember(dest => dest.Events,
            opt => opt.MapFrom(src => new List<Event>()));
        CreateMap<Str_Calendar, Calendar>();
        CreateMap<EventCreateDto, Event>()
           .ForMember(dest => dest.Id,
            opt => opt.MapFrom(src => Guid.NewGuid())); ;
        CreateMap<Event, EventReadDto>();
    }
}
