using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientCard.Domain.Events
{
    public interface IEventStore
    {
        Task SaveEventAsync(BaseEvent @event);
        Task<IEnumerable<BaseEvent>> GetEventsAsync(string aggregateId);
    }
}
