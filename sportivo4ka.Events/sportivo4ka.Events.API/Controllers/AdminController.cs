using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sportivo4ka.Events.Data.ViewModels.Input;
using sportivo4ka.Events.Data.Dto;
using sportivo4ka.Events.BI.Interfaces;
using System.IO;
using sportivo4ka.Events.General.Expansions;

namespace sportivo4ka.Events.API.Controllers
{
    [ApiController]
    [Route("events/[Controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IMapper _mapper;
        private readonly IEvent _event;

        public AdminController(ILogger<AdminController> logger, IMapper mapper, IEvent @event)
        {
            _logger = logger;
            _mapper = mapper;
            _event = @event;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddEvent([FromBody] CreateEventViewModel model)
        {
            var result = await _event.Add(_mapper.Map<EventDto>(model));
            if (result == true)
                return Ok();

            return BadRequest("Не удалось создать мероприятие!");
        }

        [HttpPost("event-add-photo")]
        public async Task<IActionResult> AddPhoto(int eventId, IFormFile photo)
        {
            var result = await _event.AddPhoto(new AddEventPhotoDto()
            {
                EventId = eventId,
                Photo = photo.OpenReadStream(),
                FileName = photo.FileName
            });
            if (result == true)
                return Ok();

            return BadRequest("Не удалось сохранить фотографию мероприятия!");
        }
    }
}
