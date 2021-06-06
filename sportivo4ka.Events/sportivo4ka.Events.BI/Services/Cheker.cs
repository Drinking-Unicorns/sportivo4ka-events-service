using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sportivo4ka.Events.EF;
using AutoMapper;
using sportivo4ka.Events.Data.Dto;
using sportivo4ka.Events.Data.Entity;
using sportivo4ka.Events.Data.Returns;
using sportivo4ka.Events.BI.Interfaces;

namespace sportivo4ka.Events.BI.Services
{
    public class Checker : IChecker
    {
        private readonly ServiceDbContext _context;
        private readonly IMapper _mapper;

        public Checker(ServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AddUserReturn> EditCodeUserToEvent(EditCodeUserToEventDto newCode)
        {
            var e = await _context.Events.SingleOrDefaultAsync(x => x.Id == newCode.EventId);

            if (e is null)
                return AddUserReturnError("Мероприятие не существует!");

            var q = await _context.UsersActivity.SingleOrDefaultAsync(x => x.UserId == newCode.UserId && x.EventId == newCode.EventId);

            if (q is null)
                return AddUserReturnError("Пользователь не записан на данное мероприятие!");

            if (newCode.EditStartCode)
                q.CodeStart = newCode.Value;
            else
                q.CodeEnd = newCode.Value;

            _context.Update(q);
            await _context.SaveChangesAsync();

            return AddUserReturnOk();

        }

        public async Task<AddUserReturn> UserAddToEvent(AddUserToEventDto user)
        {
            var e = await _context.Events.SingleOrDefaultAsync(x => x.Id == user.EventId);

            if (e is null)
                return AddUserReturnError("Мероприятие не существует!");

            var q = await _context.UsersActivity.SingleOrDefaultAsync(x => x.UserId == user.UserId && x.EventId == user.EventId);

            if (q is not null)
                return AddUserReturnError("Пользователь уже записан на данное мероприятие!");

            var entity = _mapper.Map<Event2UserEntity>(user);

            entity.Event = e;

            entity = GenerateCodes(entity);

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return AddUserReturnOk();
        }

        public async Task<CheckReturn> Check(UserChekerDto checker)
        {
            var x = await _context.UsersActivity.Include(x => x.Event)
                .SingleOrDefaultAsync(x => x.CodeStart == checker.Code && x.CodeEnd == checker.Code && x.Event.StartTime > DateTime.UtcNow && x.Event.EndTime <= DateTime.UtcNow);

            if (x is null)
                return CheckReturnError("Код неверен!");

            if (String.IsNullOrEmpty(x.CodeEnd))
                return CheckReturnError("Ошибка кода!");

            if(String.IsNullOrEmpty(x.CodeStart))
                x.CodeEnd = null;
            else
                x.CodeStart = null;

            _context.Update(x);
            await _context.SaveChangesAsync();

            return CheckReturnOk();
        }

        private Event2UserEntity GenerateCodes(Event2UserEntity entity)
        {
            entity.CodeStart = GenKey();

            if (entity.Event.EndTime.HasValue)
                entity.CodeEnd = GenKey();

            return entity;
        }

        private string GenKey()
        {
            var random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnoprstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, random.Next(20, 100)).Select(s => s[random.Next(s.Length - 1)]).ToArray());
        }

        #region ReturnsModel

        private CheckReturn CheckReturnOk() => new CheckReturn
        {
            Done = true
        };

        private CheckReturn CheckReturnError(string error) => new CheckReturn
        {
            Done = false,
            ErrorMessage = error
        };

        private AddUserReturn AddUserReturnOk() => new AddUserReturn
        {
            Done = true
        };

        private AddUserReturn AddUserReturnError(string error) => new AddUserReturn
        {
            Done = false,
            ErrorMessage = error
        };
        #endregion
    }
}
