using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientCard.Domain.Events
{
    public class PatientCardUpdated(string patientId, string name, DateTime updatedAt) : BaseEvent(patientId)
    {
        public string PatientId { get; set; }
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
