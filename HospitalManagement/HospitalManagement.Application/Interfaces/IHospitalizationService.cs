using HospitalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Interfaces
{
    public interface IHospitalizationService
    {
        Task<IEnumerable<Hospitalization>> GetAllHospitalizationsAsync();
        Task<Hospitalization?> GetHospitalizationByIdAsync(int id);
        Task<Hospitalization> CreateHospitalizationAsync(Hospitalization hospitalization);
        Task<Hospitalization?> UpdateConditionAsync(int id, string conditionDescription);
        Task<bool> DischargePatientAsync(int id);
        Task<List<HospitalizationReason>> GetAllHospitalizationReasonsAsync(); // Добавьте этот метод

    }
}
