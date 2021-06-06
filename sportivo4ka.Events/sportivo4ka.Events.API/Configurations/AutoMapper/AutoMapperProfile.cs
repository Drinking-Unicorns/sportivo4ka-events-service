using AutoMapper;
using AutoMapper.EquivalencyExpression;
using sportivo4ka.Events.Data;
using sportivo4ka.Events.Data.Entity;
using System;
using System.Linq;
using sportivo4ka.Events.Data.Dto;
using sportivo4ka.Events.Data.ViewModels.Input;

namespace sportivo4ka.Events.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EventViewModel, EventDto>();

            CreateMap<EventDto, EventEntity>();

            CreateMap<EventEntity, EventDto>();

            CreateMap<AddEventPhotoDto, AttachmentDto>()
                .ForMember(x => x.Stream, s => s.MapFrom(x => x.Photo));

            CreateMap<UserCheckViewModel, UserChekerDto>();

            CreateMap<CreateEventViewModel, EventDto>()
                .ForMember(x => x.Address, s => s.MapFrom<CreateEventToDto>());

            CreateMap<AddUserToEventViewModel, AddUserToEventDto>();

            CreateMap<AddUserToEventDto, Event2UserEntity>();
        }
    }
}
