using AutoMapper;
using Newtonsoft.Json.Linq;
using sportivo4ka.Events.BI.Options;
using sportivo4ka.Events.Data.Entity;
using sportivo4ka.Events.General.Expansions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using sportivo4ka.Events.Data.Dto;
using sportivo4ka.Events.Data.ViewModels.Input;
using sportivo4ka.Events.Data.Base;
using sportivo4ka.Events.BI.Interfaces;

namespace sportivo4ka.Events.API.Configurations.AutoMapper
{
    public class FormatterObjectToString : IValueResolver<object, object, string>
    {
        private readonly IMapper _mapper;

        public FormatterObjectToString(IMapper mapper)
        {
            _mapper = mapper;
        }

        public string Resolve(object source, object destination, string result, ResolutionContext context)
        {
            return result;
        }
    }

    public class CreateEventToDto : IValueResolver<CreateEventViewModel, EventDto, string>
    {
        private readonly IMapper _mapper;
        private readonly IDadata _dadata;

        public CreateEventToDto(IMapper mapper, IDadata dadata)
        {
            _mapper = mapper;
            _dadata = dadata;
        }

        public string Resolve(CreateEventViewModel source, EventDto destination, string result, ResolutionContext context)
        {
            if (String.IsNullOrEmpty(source.Address))
                return _dadata.GetAddress(source.Cords);

            return source.Address;
        }
    }

}