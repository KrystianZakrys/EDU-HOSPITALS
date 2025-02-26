using PatientCard.Domain.Entities;
using PatientCard.Domain.Events;

namespace PatientCard.Application.Services
{
    public class PatientCardHistoryService
    {
        private readonly IEventStore _eventStore;

        public PatientCardHistoryService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task CreatePatientCardAsync(PatientCardHistory patientCardHistory)
        {
            throw new NotImplementedException();
            //var event = new PatientCardCreated(patientCard.Id, patientCard.Name, patientCard.DateOfBirth);
            //await _eventStore.SaveEventAsync(event);
        }
    }
}
