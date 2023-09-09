using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAPI.Entities.DTOs
{
    public class EventDTO
    {
        public long idEvent { get; set; }
        public string descriptionEvent { get; set; }
        public int typeEvent { get; set; }
        public DateTime dateEvent { get; set; }
    }
}
