using Microsoft.AspNetCore.Mvc;
using LogAPI.Service.Interface;
using LogAPI.Entities.DTOs;

namespace LogAPI.Controllers.api.eventLog
{
    [ApiController]
    [Route("api/eventLog")]
    public class EventLogsController : Controller
    {
        private readonly ILogEventService _eventLogService;
        public EventLogsController(ILogEventService eventLogService)
        {
            _eventLogService = eventLogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventLogs()
        {
            var eventLogs = await _eventLogService.GetAllEventsAsync();
            return Ok(eventLogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventLogsById(long id)
        {
            var eventLogs = await _eventLogService.GetEventsByIdAsync(id);
            return Ok(eventLogs); ;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventDTO eventDTO)
        {
            var res = await _eventLogService.AddEventAsync(eventDTO);
            return Ok(new { id = res });
        }
    }
}
