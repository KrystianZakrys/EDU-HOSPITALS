
using Clinics.Domain.Entities;
using Clinics.Domain.Repositories;
using MongoDB.Driver;

namespace Clinics.Infrastructure.Repositories
{
    public class ClinicRepository : IClinicRepository<Clinic>
    {
        private readonly IMongoCollection<Clinic> _clinics;

        public ClinicRepository(IMongoDatabase database)
        {
            _clinics = database.GetCollection<Clinic>("Clinics");
        }

        public async Task AddAsync(Clinic clinic)
        {
            await _clinics.InsertOneAsync(clinic);
        }

        public async Task DeleteAsync(string id)
        {
            await _clinics.DeleteOneAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Clinic>> GetAllAsync()
        {
            return await _clinics.Find(_ => true).ToListAsync();
        }

        public async Task<Clinic> GetByIdAsync(string id)
        {
            return await _clinics.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Clinic clinic)
        {
            await _clinics.ReplaceOneAsync(e => e.Id == clinic.Id, clinic);
        }
    }
}
