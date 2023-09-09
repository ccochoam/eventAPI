using LogAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAPI.Data.Interface
{
    public interface ILogEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventsByIdAsync(long id);
        Task<long> AddEventAsync(Event @event);
    }
}
