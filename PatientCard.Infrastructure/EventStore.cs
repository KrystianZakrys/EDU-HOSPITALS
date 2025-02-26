using MongoDB.Driver;
using PatientCard.Domain.Events;

namespace PatientCard.Infrastructure
{
    public class EventStore : IEventStore
    {
        private readonly IMongoCollection<BaseEvent> _eventCollection;

        public EventStore(IMongoDatabase database)
        {
            _eventCollection = database.GetCollection<BaseEvent>("PatientCardEvents");
        }    

        public async Task SaveEventAsync(BaseEvent eventToSave)
        {
            await _eventCollection.InsertOneAsync(eventToSave);
        }

        public async Task<IEnumerable<BaseEvent>> GetEventsAsync(string patientId)
        {
            return await _eventCollection.Find(e => e.AggregateId == patientId).ToListAsync();
        }
    } 
}
