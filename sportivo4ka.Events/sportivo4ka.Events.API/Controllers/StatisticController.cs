using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sportivo4ka.Events.BI.Interfaces;
using sportivo4ka.Events.Data.Dto;
using sportivo4ka.Events.Data.ViewModels.Input;

namespace sportivo4ka.Events.API.Controllers
{
    [ApiController]
    [Route("events/[Controller]")]
    public class StatisticController : ControllerBase
    {
        private readonly ILogger<StatisticController> _logger;
        private readonly IMapper _mapper;
        private readonly IChecker _checker;
        private readonly IStatistic _statistic;

        public StatisticController(ILogger<StatisticController> logger, IMapper mapper, IChecker cheker, IStatistic statistic)
        {
            _logger = logger;
            _mapper = mapper;
            _checker = cheker;
            _statistic = statistic;
        }
    }
}
