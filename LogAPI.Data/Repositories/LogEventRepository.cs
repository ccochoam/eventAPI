using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogAPI.Data.Context;
using LogAPI.Data.Interface;
using LogAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LogAPI.Data.Repositories
{
    public class LogEventRepository: ILogEventRepository
    {
        private readonly LogEventDbContext _logEventDbContext;

        public LogEventRepository(LogEventDbContext logEventDbContext)
        {
            _logEventDbContext = logEventDbContext;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            try
            {
                return await _logEventDbContext.Event.ToListAsync();
            }
            catch (Exception e)
            {
                var ex = e;
            }
            return null;
        }

        public async Task<Event> GetEventsByIdAsync(long id)
        {
            try
            {
                return await _logEventDbContext.Event.SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception e)
            {
                var ex = e;
            }
            return null;
        }

        public async Task<long> AddEventAsync(Event @event)
        {
            try
            {
                _logEventDbContext.Event.Add(@event);
                await _logEventDbContext.SaveChangesAsync();
                return @event.Id;
            }
            catch (Exception e)
            {
                var ex = e;
            }
            return @event.Id;
        }
    }
}
