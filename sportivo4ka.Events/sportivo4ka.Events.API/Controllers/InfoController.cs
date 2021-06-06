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
using sportivo4ka.Events.Data.Base;

namespace sportivo4ka.Events.API.Controllers
{
    [ApiController]
    [Route("events/[Controller]")]
    public class InfoController : ControllerBase
    {
        private readonly ILogger<InfoController> _logger;
        private readonly IMapper _mapper;
        private readonly IEvent _event;

        public InfoController(ILogger<InfoController> logger, IMapper mapper, IEvent @event)
        {
            _logger = logger;
            _mapper = mapper;
            _event = @event;
        }

        [HttpGet("get-event")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var result = await _event.GetAsync(id);
            if(result.Done)
                return Ok(result.Event);

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("get-all-events")]
        public async Task<IActionResult> GetAllEvents()
        {
            var result = await _event.GetAll();
            if (result.Done)
                return Ok(result.Events);

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("get-events-user")]
        public async Task<IActionResult> GetEventsUser(int userId)
        {
            var result = await _event.GetAll(userId);
            if (result.Done)
                return Ok(result.Events);

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("get-events")]
        public async Task<IActionResult> GetEventsForFilter(Filter filter)
        {
            var result = await _event.GetAll(filter);
            if (result.Done)
                return Ok(result.Events);

            return BadRequest(result.ErrorMessage);
        }
    }
}
