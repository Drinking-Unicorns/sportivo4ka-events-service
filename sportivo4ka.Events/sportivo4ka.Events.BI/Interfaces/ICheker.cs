using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.Data.Returns;
using sportivo4ka.Events.Data.Dto;

namespace sportivo4ka.Events.BI.Interfaces
{
    public interface IChecker
    {
        Task<AddUserReturn> UserAddToEvent(AddUserToEventDto user);

        Task<CheckReturn> Check(UserChekerDto cheker);

        Task<AddUserReturn> EditCodeUserToEvent(EditCodeUserToEventDto newCode);
    }
}
