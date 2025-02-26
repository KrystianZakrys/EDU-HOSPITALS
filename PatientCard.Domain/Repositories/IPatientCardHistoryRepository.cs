using PatientCard.Domain.Entities;

namespace PatientCard.Domain.Repositories
{
    public interface IPatientCardHistoryRepository<PatientCardHistory>
    {
        Task<PatientCardHistory> GetByIdAsync(string id);
        Task<IEnumerable<PatientCardHistory>> GetAllAsync();
        Task AddAsync(PatientCardHistory entity);
        Task UpdateAsync(PatientCardHistory entity);
        Task DeleteAsync(string id);
    }
}
