using Hospitals.Domain.Entities;
using Hospitals.Domain.Repositories;
using MongoDB.Driver;


namespace Hospitals.Infrastructure.Repository
{
    public class HospitalRepository : IHospitalRepository<Hospital>
    {
        private readonly IMongoCollection<Hospital> _hospitals;

        public HospitalRepository(IMongoDatabase database)
        {
            _hospitals = database.GetCollection<Hospital>("Emergencies");
        }

        public async Task AddAsync(Hospital clinic)
        {
            await _hospitals.InsertOneAsync(clinic);
        }

        public async Task DeleteAsync(string id)
        {
            await _hospitals.DeleteOneAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Hospital>> GetAllAsync()
        {
            return await _hospitals.Find(_ => true).ToListAsync();
        }

        public async Task<Hospital> GetByIdAsync(string id)
        {
            return await _hospitals.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Hospital clinic)
        {
            await _hospitals.ReplaceOneAsync(e => e.Id == clinic.Id, clinic);
        }
    }
}
