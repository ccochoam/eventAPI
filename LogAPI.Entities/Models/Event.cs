using System;

namespace LogAPI.Entities.Models
{
    public class Event
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int EventType { get; set; }
        public DateTime EventDate { get; set; }
    }
}
