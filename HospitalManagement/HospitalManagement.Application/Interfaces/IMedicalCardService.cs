using HospitalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Interfaces
{
    public interface IMedicalCardService
    {
        Task<IEnumerable<MedicalCard>> GetAllMedicalCardsAsync();
        Task<MedicalCard?> GetMedicalCardByIdAsync(int id);
        Task<MedicalCard> CreateMedicalCardAsync(MedicalCard medicalCard);
        Task<MedicalCard?> UpdateMedicalCardAsync(int id, MedicalCard updatedMedicalCard);
        Task<bool> DeleteMedicalCardAsync(int id);
    }
}
