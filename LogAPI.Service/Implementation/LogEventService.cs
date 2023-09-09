using LogAPI.Data.Interface;
using LogAPI.Entities.Models;
using LogAPI.Entities.DTOs;
using LogAPI.Service.Interface;
using System.Diagnostics.Tracing;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace LogAPI.Service.Implementation
{
    public class LogEventService : ILogEventService
    {
        private readonly ILogEventRepository _logEventRepository;
        public LogEventService(ILogEventRepository logEventRepository)
        {
            _logEventRepository = logEventRepository;
        }
        public async Task<IEnumerable<EventDTO>> GetAllEventsAsync()
        {
            var res = await _logEventRepository.GetAllEventsAsync();
            return MapEventToDTO(res);
        }

        public async Task<EventDTO> GetEventsByIdAsync(long id)
        {
            var res = await _logEventRepository.GetEventsByIdAsync(id);
            return MapEventToDTO(res);
        }
        public async Task<long> AddEventAsync(EventDTO eventDTO)
        {
            var newEvent = MapDtoToEventLog(eventDTO);
            var id = await _logEventRepository.AddEventAsync(newEvent);
            return id;
        }

        public Event MapDtoToEventLog(EventDTO eventDTO)
        {
            return new Event { 
                Description = eventDTO.descriptionEvent, 
                EventDate = eventDTO.dateEvent, 
                EventType = eventDTO.typeEvent 
            };
        }
        public IEnumerable<EventDTO> MapEventToDTO(IEnumerable<Event> @event)
        {
            if (@event == null) return null;
            IEnumerable<EventDTO> events =
                @event.Select(e => new EventDTO
                {
                    descriptionEvent = e.Description,
                    idEvent = e.Id,
                    typeEvent = e.EventType,
                    dateEvent = e.EventDate
                });
            return events;
        }
        public EventDTO MapEventToDTO(Event @event)
        {
            return new EventDTO { 
                descriptionEvent = @event.Description, 
                idEvent = @event.Id,
                typeEvent = @event.EventType,
                dateEvent = @event.EventDate
            };
        }
    }
}
