using HospitalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Interfaces
{
    public interface ISpecializationService
    {
        Task<IEnumerable<Specialization>> GetAllSpecializationsAsync();
        Task<Specialization?> GetSpecializationByIdAsync(int id);
        Task<Specialization> CreateSpecializationAsync(Specialization specialization);
        Task<Specialization?> UpdateSpecializationAsync(int id, Specialization updatedSpecialization);
        Task<bool> DeleteSpecializationAsync(int id);
    }
}
