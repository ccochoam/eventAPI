using LogAPI.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAPI.Service.Interface
{
    public interface ILogEventService
    {
        Task<IEnumerable<EventDTO>> GetAllEventsAsync();
        Task<EventDTO> GetEventsByIdAsync(long id);
        Task<long> AddEventAsync(EventDTO @event);
    }
}
