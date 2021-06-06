using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportivo4ka.Events.Data.Dto
{
    public class EditCodeUserToEventDto
    {
        public int UserId { get; set; }

        public int EventId { get; set; }

        //Если True, меняем стартовый код. Если False - конечный
        public bool EditStartCode { get; set; }

        public string Value { get; set; }
    }
}
