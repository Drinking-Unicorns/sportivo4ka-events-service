using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.Data.Returns;
using sportivo4ka.Events.Data.Base;
using sportivo4ka.Events.Data.Dto;

namespace sportivo4ka.Events.BI.Interfaces
{
    public interface IEvent
    {
        Task<EventReturn> GetAsync(int id);

        Task<EventsReturn> GetAll();

        Task<EventsReturn> GetAll(int userId);

        Task<EventsReturn> GetAll(Filter filter);

        Task<bool> Add(EventDto e);

        Task<bool> AddPhoto(AddEventPhotoDto photo);

        Task<bool> Update(EventDto e);
    }
}
