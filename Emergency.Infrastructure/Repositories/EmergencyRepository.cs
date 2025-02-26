
using Emergency.Domain.Entities;
using Emergency.Domain.Repositories;
using MongoDB.Driver;

namespace Emergency.Infrastructure.Repositories
{
    public class EmergencyRepository : IEmergencyRepository<EmergencyEntity>
    {
        private readonly IMongoCollection<EmergencyEntity> _emergencies;

        public EmergencyRepository(IMongoDatabase database)
        {
            _emergencies = database.GetCollection<EmergencyEntity>("Emergencies");
        }

        public async Task AddAsync(EmergencyEntity clinic)
        {
            await _emergencies.InsertOneAsync(clinic);
        }

        public async Task DeleteAsync(string id)
        {
            await _emergencies.DeleteOneAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<EmergencyEntity>> GetAllAsync()
        {
            return await _emergencies.Find(_ => true).ToListAsync();
        }

        public async Task<EmergencyEntity> GetByIdAsync(string id)
        {
            return await _emergencies.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(EmergencyEntity clinic)
        {
            await _emergencies.ReplaceOneAsync(e => e.Id == clinic.Id, clinic);
        }
    }
}
