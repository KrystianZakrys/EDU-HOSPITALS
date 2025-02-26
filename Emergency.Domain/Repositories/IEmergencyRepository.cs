namespace Emergency.Domain.Repositories
{
    public interface IEmergencyRepository<EmergencyEntity>
    {
        Task<EmergencyEntity> GetByIdAsync(string id);
        Task<IEnumerable<EmergencyEntity>> GetAllAsync();
        Task AddAsync(EmergencyEntity entity);
        Task UpdateAsync(EmergencyEntity entity);
        Task DeleteAsync(string id);
    }
}
