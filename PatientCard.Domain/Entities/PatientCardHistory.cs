using PatientCard.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientCard.Domain.Entities
{
    public class PatientCardHistory
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public PatientCardHistory(string patientId)
        {
            Id = patientId;
        }

        public void Apply(PatientCardCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            DateOfBirth = @event.DateOfBirth;
        }

        public void Apply(PatientCardUpdated @event)
        {
            Name = @event.Name;
        }

        public static PatientCardHistory Create(string patientId, string name, DateTime dateOfBirth)
        {
            var patientCard = new PatientCardHistory(patientId);
            PatientCardCreated patientCardCreatedEvent = new PatientCardCreated(patientId, name, dateOfBirth, DateTime.UtcNow);

            patientCard.Apply(patientCardCreatedEvent);
            return patientCard;
        }
    }
}
