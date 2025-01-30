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
    public class SpecializationService : ISpecializationService
    {
        private readonly HospitalDbContext _context;

        public SpecializationService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Specialization>> GetAllSpecializationsAsync()
        {
            return await _context.Specializations.ToListAsync();
        }

        public async Task<Specialization?> GetSpecializationByIdAsync(int id)
        {
            return await _context.Specializations.FindAsync(id);
        }

        public async Task<Specialization> CreateSpecializationAsync(Specialization specialization)
        {
            _context.Specializations.Add(specialization);
            await _context.SaveChangesAsync();
            return specialization;
        }

        public async Task<Specialization?> UpdateSpecializationAsync(int id, Specialization updatedSpecialization)
        {
            var specialization = await _context.Specializations.FindAsync(id);
            if (specialization == null) return null;

            specialization.Name = updatedSpecialization.Name;

            await _context.SaveChangesAsync();
            return specialization;
        }

        public async Task<bool> DeleteSpecializationAsync(int id)
        {
            var specialization = await _context.Specializations.FindAsync(id);
            if (specialization == null) return false;

            _context.Specializations.Remove(specialization);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
