using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientCard.Domain.Events
{
    public class PatientCardCreated : BaseEvent
    {
        public PatientCardCreated(string patientId, string name, DateTime dateOfBirth, DateTime createdAt)
        : base(patientId)
        {
            Id = patientId;
            Name = name;
            DateOfBirth = dateOfBirth;
            CreatedAt = createdAt;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
