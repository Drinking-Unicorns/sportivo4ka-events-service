using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sportivo4ka.Events.Data.ViewModels.Input;
using sportivo4ka.Events.Data.Dto;
using sportivo4ka.Events.BI.Interfaces;

namespace sportivo4ka.Events.API.Controllers
{
    [ApiController]
    [Route("events/[Controller]")]
    public class CheckerController : ControllerBase
    {
        private readonly ILogger<CheckerController> _logger;
        private readonly IMapper _mapper;
        private readonly IChecker _checker;
        private readonly IEvent _event;

        public CheckerController(ILogger<CheckerController> logger, IMapper mapper, IChecker checker)
        {
            _logger = logger;
            _mapper = mapper;
            _checker = checker;
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUserToEvent([FromBody] AddUserToEventViewModel model)
        {
            var result = await _checker.UserAddToEvent(_mapper.Map<AddUserToEventDto>(model));

            if (result.Done)
                return Ok(result.Done);

            return BadRequest(result.ErrorMessage);
        }

        [HttpPost("check")]
        public async Task<IActionResult> Check([FromBody] UserCheckViewModel model)
        {
            var result = await _checker.Check(_mapper.Map<UserChekerDto>(model));

            if (result.Done)
                return Ok(result.Done);

            return BadRequest(result.ErrorMessage);
        }

        [HttpPost("EditCodeForUserToEvent")]
        public async Task<IActionResult> EditCodeForUserToEvent([FromBody] EditCodeUserToEventDto model)
        {
            var result = await _checker.EditCodeUserToEvent(model);

            if (result.Done)
                return Ok(result.Done);

            return BadRequest(result.ErrorMessage);
        }
    }
}
