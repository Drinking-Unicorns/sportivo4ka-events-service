using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.BI.Interfaces;
using sportivo4ka.Events.BI.Options;
using sportivo4ka.Events.Data.Dto;
using AutoMapper;

namespace sportivo4ka.Events.BI.Services
{
    public class Users : IUsers
    {
        private readonly IDataSend _sender;
        private readonly IMapper _mapper;
        private readonly UsersServiceConfig _config;

        public Users(IDataSend sender, IMapper mapper, UsersServiceConfig config)
        {
            _mapper = mapper;
            _sender = sender;
        }

        public async Task SendPoints(SendPointDto points)
        {
            await _sender.Post(points, _config.AddPoint.Url);
        }
    }
}
