using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitals.Domain.Repositories
{
    public interface IHospitalRepository<Hospital>
    {
        Task<Hospital> GetByIdAsync(string id);
        Task<IEnumerable<Hospital>> GetAllAsync();
        Task AddAsync(Hospital entity);
        Task UpdateAsync(Hospital entity);
        Task DeleteAsync(string id);
    }
}
