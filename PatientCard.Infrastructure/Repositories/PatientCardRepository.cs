using PatientCard.Domain.Entities;
using PatientCard.Domain.Repositories;

namespace PatientCard.Infrastructure.Repositories
{
    public class PatientCardRepository : IPatientCardHistoryRepository<PatientCardHistory>
    {
        public Task AddAsync(PatientCardHistory entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PatientCardHistory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PatientCardHistory> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PatientCardHistory entity)
        {
            throw new NotImplementedException();
        }
    }
}
