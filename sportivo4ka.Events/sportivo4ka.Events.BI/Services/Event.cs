using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.EF;
using AutoMapper;
using sportivo4ka.Events.BI.Interfaces;
using sportivo4ka.Events.Data.Returns;
using sportivo4ka.Events.Data.Dto;
using sportivo4ka.Events.Data.Entity;
using sportivo4ka.Events.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace sportivo4ka.Events.BI.Services
{
    public class Event : IEvent
    {
        private readonly ServiceDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAttachment _attachment;

        public Event(ServiceDbContext context, IMapper mapper, IAttachment attachment)
        {
            _context = context;
            _mapper = mapper;
            _attachment = attachment;
        }

        public EventReturn Get(int id)
        {
            var @event = _context.Events.SingleOrDefault(x => x.Id == id);

            if (@event is null || @event.Id == 0)
                return EventReturnError("Мероприятие не найдено!");

            return EventReturnOk(_mapper.Map<EventDto>(@event));
        }

        public async Task<EventReturn> GetAsync(int id)
        {
            var @event = await _context.Events.SingleOrDefaultAsync(x => x.Id == id);

            if (@event is null || @event.Id == 0)
                return EventReturnError("Мероприятие не найдено!");

            return EventReturnOk(_mapper.Map<EventDto>(@event));
        }

        public async Task<EventsReturn> GetAll()
        {
            var events = await _context.Events.Include(x => x.Tags).Include(x => x.Cords).ToListAsync();

            if (!events.Any())
                return EventsReturnError("Мероприятий не найдено!");

            return EventsReturnOk(_mapper.Map<List<EventEntity>, List<EventDto>>(events));
        }

        public async Task<EventsReturn> GetAll(int userId)
        {
            var events = await _context.UsersActivity.Include(x => x.Event).Where(x => x.UserId == userId).Select(x => x.Event).ToListAsync();

            if (!events.Any())
                return EventsReturnError("Мероприятий не найдено!");

            return EventsReturnOk(_mapper.Map<List<EventEntity>, List<EventDto>>(events));

        }

        public async Task<EventsReturn> GetAll(Filter filter)
        {
            IQueryable<Event2UserEntity> events = _context.UsersActivity.Include(x => x.Event);

            if (filter.UserCords.Lat > 0 && filter.UserCords.Lng > 0)
                events = events.Where(x => x.Event.Cords.Distantion(filter.UserCords) <= filter.MaxDistantion);

            if (!events.Any())
                return EventsReturnError("Мероприятий не найдено!");

            return EventsReturnOk(_mapper.Map<List<EventEntity>, List<EventDto>>(await events.Select(x => x.Event).ToListAsync()));
        }

        public async Task<bool> Add(EventDto e)
        {
            var entity = _mapper.Map<EventEntity>(e);
            await _context.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0)
                return true;

            return false;
        }

        public async Task<bool> AddPhoto(AddEventPhotoDto photo)
        {
            var q = await _context.Events.SingleOrDefaultAsync(x => x.Id == photo.EventId);

            if (q is null)
                return false;

            var url = await _attachment.Upload(_mapper.Map<AttachmentDto>(photo));

            if (String.IsNullOrEmpty(url))
                return false;

            q.EventPhotoUrl = url;

            _context.Update(q);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(EventDto e)
        {
            return true;
        }

        #region ReturnsModel

        public EventReturn EventReturnOk(EventDto e) => new EventReturn
        {
            Done = true,
            Event = e
        };

        public EventReturn EventReturnError(string error) => new EventReturn
        {
            Done = false,
            ErrorMessage = error
        };

        public EventsReturn EventsReturnOk(IList<EventDto> events) => new EventsReturn
        {
            Done = true,
            Events = events
        };

        public EventsReturn EventsReturnError(string error) => new EventsReturn
        {
            Done = false,
            ErrorMessage = error
        };


        #endregion

    }
}
