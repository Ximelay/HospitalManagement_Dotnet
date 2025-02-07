using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Services
{
    public class HospitalizationService : IHospitalizationService
    {
        private readonly HospitalDbContext _context;

        public HospitalizationService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hospitalization>> GetAllHospitalizationsAsync()
        {
            return await _context.Hospitalizations
                .Include(h => h.Patient)
                .Include(h => h.HospitalizationReason)
                .ToListAsync();
        }

        public async Task<Hospitalization?> GetHospitalizationByIdAsync(int id)
        {
            return await _context.Hospitalizations
                .Include(h => h.Patient)
                .Include(h => h.HospitalizationReason)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Hospitalization> CreateHospitalizationAsync(Hospitalization hospitalization)
        {
            _context.Hospitalizations.Add(hospitalization);
            await _context.SaveChangesAsync();
            return hospitalization;
        }

        public async Task<Hospitalization?> UpdateConditionAsync(int id, string conditionDescription)
        {
            var hospitalization = await _context.Hospitalizations.FindAsync(id);
            if (hospitalization == null) return null;

            hospitalization.ConditionDescription = conditionDescription;
            await _context.SaveChangesAsync();
            return hospitalization;
        }

        public async Task<bool> DischargePatientAsync(int id)
        {
            var hospitalization = await _context.Hospitalizations.FindAsync(id);
            if (hospitalization == null) return false;

            _context.Hospitalizations.Remove(hospitalization);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<HospitalizationReason>> GetAllHospitalizationReasonsAsync()
        {
            try
            {
                return await _context.HospitalizationReasons.ToListAsync();
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Console.WriteLine($"Error retrieving hospitalization reasons: {ex.Message}");
                throw;
            }
        }
    }
}
