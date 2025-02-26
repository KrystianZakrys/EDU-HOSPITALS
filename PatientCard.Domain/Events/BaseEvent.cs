using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientCard.Domain.Events
{
    public abstract class BaseEvent
    {
        public string EventId { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string AggregateId { get; private set; }

        protected BaseEvent(string aggregateId)
        {
            EventId = Guid.NewGuid().ToString();
            Timestamp = DateTime.UtcNow;
            AggregateId = aggregateId;
        }
    }
}
